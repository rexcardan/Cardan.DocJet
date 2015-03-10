using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Cardan.DocJet.Maps;

namespace Cardan.DocJet.XML
{
    public class JetElement
    {
        private readonly XElement _underlying;

        /// <summary>
        ///     Creates a new element from scratch
        /// </summary>
        /// <param name="xName">the name of the element to create</param>
        public JetElement(XName xName)
        {
            _underlying = new XElement(xName);
        }

        /// <summary>
        ///     Wraps an already existing element
        /// </summary>
        /// <param name="el">the element to wrap</param>
        public JetElement(XElement el)
        {
            _underlying = el;
        }

        #region VAL

        public string GetVal(XName xName, int numberToGet = 0)
        {
            if (_underlying.Descendants(xName).Count() > numberToGet)
            {
                XElement found = _underlying.Descendants(xName).Skip(numberToGet).FirstOrDefault();
                return found.Attribute("val").Value;
            }
            return string.Empty;
        }

        public string GetValue(params XName[] nodeChain)
        {
            return Get(nodeChain).Value;
        }

        public T GetVal<T>(XName xName, int numberToGet = 0)
        {
            string val = GetVal(xName, numberToGet);
            if (typeof (T) == typeof (int))
            {
                int i = int.MinValue;
                int.TryParse(val, out i);
                return (T) (object) i;
            }
            if (typeof (T) == typeof (double))
            {
                double d = double.MinValue;
                double.TryParse(val, out d);
                return (T) (object) d;
            }
            if (typeof (T).IsSubclassOf(typeof (JetMap)))
            {
                object instance = Activator.CreateInstance(typeof (T), val);
                return (T) instance;
            }
            return default(T);
        }

        public List<string> GetVals(XName xName)
        {
            if (_underlying.Descendants(xName).FirstOrDefault() != null)
            {
                List<string> found = _underlying.Descendants(xName).Select(d => d.Attribute("val").Value).ToList();
                return found;
            }
            return new List<string>();
        }

        public void SetVal(XName xName, object value, int elNumberToSet = 0)
        {
            if (_underlying.Descendants(xName).Count() > elNumberToSet)
            {
                XElement found = _underlying.Descendants(xName).Skip(elNumberToSet).FirstOrDefault();
                found.Attribute("val").Value = value.ToString();
            }
            else
            {
                _underlying.Add(new XElement(xName, new XAttribute("val", value)));
            }
        }

        public void SetVal(XName xName, JetMap value, int elNumberToSet = 0)
        {
            if (_underlying.Descendants(xName).Count() > elNumberToSet)
            {
                XElement found = _underlying.Descendants(xName).Skip(elNumberToSet).FirstOrDefault();
                found.Attribute("val").Value = value.Wrapped;
            }
            else
            {
                _underlying.Add(new XElement(xName, new XAttribute("val", value.Wrapped)));
            }
        }

        public T GetEnumMappedVal<T>(XName xName) where T : struct
        {
            string val = GetVal(xName);
            T map;
            Enum.TryParse(val, true, out map);
            return map;
        }

        public void SetEnumMappedVal<T>(XName xName, T value) where T : struct
        {
            string val = value.ToString().ToLower();
            SetVal(xName, val);
        }

        #endregion

        /// <summary>
        ///     Return the underlying wrapped element
        /// </summary>
        public XElement WrappedElement
        {
            get { return _underlying; }
        }

        public void Add(JetElement el)
        {
            WrappedElement.Add(el.WrappedElement);
        }

        public void AddAfterSelf(JetElement el)
        {
            WrappedElement.AddAfterSelf(el.WrappedElement);
        }

        public XElement Get(params XName[] descendantOrder)
        {
            return GetAfter(_underlying, descendantOrder);
        }

        public XElement GetAfter(XElement el, params XName[] descendantOrder)
        {
            if (el == null)
            {
                return el;
            }
            XElement current = el;
            for (int i = 0; i < descendantOrder.Length - 1; i++)
            {
                current =
                    current.Descendants(descendantOrder[i])
                        .FirstOrDefault(f => f.Descendants(descendantOrder[i + 1]).Count() > 0);
                if (current == null)
                {
                    return null;
                }
            }
            return current.Descendants(descendantOrder[descendantOrder.Length - 1]).FirstOrDefault();
        }

        public T Get<T>(XName xName) where T : JetElement
        {
            if (_underlying.Descendants(xName).FirstOrDefault() != null)
            {
                return (T) Activator.CreateInstance(typeof (T), _underlying.Descendants(xName).First());
            }
            return null;
        }

        public IEnumerable<T> GetAll<T>(params XName[] descendantOrder) where T : JetElement
        {
            XElement current = null;
            for (int i = 0; i < descendantOrder.Length - 1; i++)
            {
                current =
                    _underlying.Descendants(descendantOrder[i])
                        .FirstOrDefault(f => f.Descendants(descendantOrder[i + 1]).Count() > 0);
                if (current == null)
                {
                    return null;
                }
            }
            return
                _underlying.Descendants(descendantOrder[descendantOrder.Length - 1])
                    .Select(d => (T) Activator.CreateInstance(typeof (T), d));
        }

        public string GetFirstMatchDescendantInnerXML(params XName[] descendantOrder)
        {
            XElement current = null;
            for (int i = 0; i < descendantOrder.Length - 1; i++)
            {
                current =
                    _underlying.Descendants(descendantOrder[i])
                        .FirstOrDefault(f => f.Descendants(descendantOrder[i + 1]).Count() > 0);
                if (current == null)
                {
                    return null;
                }
            }
            return current.Descendants(descendantOrder[descendantOrder.Length - 1]).First().Value;
        }

        public string GetFirstMatchDescendantAttVal(XName attributeName, params XName[] descendantOrder)
        {
            XElement current = null;
            for (int i = 0; i < descendantOrder.Length - 1; i++)
            {
                current =
                    _underlying.Descendants(descendantOrder[i])
                        .FirstOrDefault(f => f.Descendants(descendantOrder[i + 1]).Count() > 0);
                if (current == null)
                {
                    return null;
                }
            }
            XAttribute attr =
                current.Descendants(descendantOrder[descendantOrder.Length - 1])
                    .FirstOrDefault()
                    .Attribute(attributeName);
            return attr != null ? attr.Value : null;
        }

        public XElement GetAnyOf(int elNumberToFind, params XName[] possibleNames)
        {
            int found = 0;
            foreach (XElement desc in _underlying.Descendants())
            {
                foreach (XName name in possibleNames)
                {
                    if (desc.Name == name)
                    {
                        if (found == elNumberToFind)
                        {
                            return desc;
                        }
                        found++;
                        break;
                    }
                }
            }
            return null;
        }

        public List<XElement> GetAll(params XName[] descendantOrder)
        {
            var found = new List<XElement> {WrappedElement};
            for (int i = 0; i < descendantOrder.Length; i++)
            {
                var localFound = new List<XElement>();
                foreach (XElement el in found)
                {
                    el.Descendants(descendantOrder[i]).ToList().ForEach(d => localFound.Add(d));
                }
                found = localFound;
            }
            return found;
        }

        public void Set(XName xName, JetElement setEl, int numberToReplace = 0)
        {
            if (_underlying.Descendants(xName).Count() > numberToReplace)
            {
                _underlying.Descendants(xName).ToList()[numberToReplace].ReplaceWith(setEl._underlying);
            }
            else
            {
                _underlying.Add(setEl._underlying);
            }
        }

        public void SetAnyOf(int elNumberToSet, JetElement el, params XName[] possibleNames)
        {
            int found = 0;
            foreach (XElement desc in _underlying.Descendants())
            {
                foreach (XName name in possibleNames)
                {
                    if (desc.Name == name)
                    {
                        if (found == elNumberToSet)
                        {
                            desc.ReplaceWith(el._underlying);
                        }
                        else
                        {
                            found++;
                            break;
                        }
                    }
                }
            }
            if (found == elNumberToSet)
            {
                _underlying.Add(el._underlying);
            }
        }

        public void Set(JetElement setEl, int numberToReplace = 0)
        {
            Set(setEl._underlying.Name, setEl, numberToReplace);
        }

        public void SetFirstMatchDescendantAttVal(XName attributeName, object value, params XName[] descendantOrder)
        {
            XElement current = null;
            for (int i = 0; i < descendantOrder.Length - 1; i++)
            {
                current =
                    _underlying.Descendants(descendantOrder[i])
                        .FirstOrDefault(f => f.Descendants(descendantOrder[i + 1]).Count() > 0);
                if (current == null)
                {
                    return;
                }
            }
            current.Descendants(descendantOrder[descendantOrder.Length - 1])
                .FirstOrDefault()
                .SetAttributeValue(attributeName, value);
        }

        public void SetFirstMatchDescendantInnerXML(string value, params XName[] descendantOrder)
        {
            XElement current = null;
            for (int i = 0; i < descendantOrder.Length - 1; i++)
            {
                current =
                    _underlying.Descendants(descendantOrder[i])
                        .FirstOrDefault(f => f.Descendants(descendantOrder[i + 1]).Count() > 0);
                if (current == null)
                {
                    return;
                }
            }
            current.Descendants(descendantOrder[descendantOrder.Length - 1]).FirstOrDefault().Value = value;
        }

        /// <summary>
        ///     If element chain does not exist, this will forge a chain and make it exist.
        /// </summary>
        /// <param name="el">the starting element of the chain (already exists)</param>
        /// <param name="descendantOrder">the descendant XNames to be added to the chain if they don't already exist</param>
        public void Forge(params XName[] descendantOrder)
        {
            XElement current = _underlying;
            XElement next = null;
            for (int i = 0; i < descendantOrder.Length; i++)
            {
                next = _underlying.Element(descendantOrder[i]);
                if (next == null)
                {
                    for (int j = i; j < descendantOrder.Length; j++)
                    {
                        current.Add(new XElement(descendantOrder[j]));
                        current = _underlying.Element(descendantOrder[j]);
                        i = j;
                    }
                }
                else
                {
                    current = next;
                }
            }
        }

        public void Remove(params XName[] names)
        {
            foreach (XName name in names)
            {
                WrappedElement.Descendants(name).Remove();
            }
        }

        public void ReplaceOrAdd(XElement el)
        {
            if (el != null)
            {
                XElement exist = WrappedElement.Element(el.Name);
                if (exist != null)
                {
                    exist.ReplaceWith(el);
                }
                else
                {
                    WrappedElement.Add(el);
                }
            }
        }

        public void ReplaceRemoveOrAdd(XName name, XElement el)
        {
            XElement exist = WrappedElement.Element(name);
            if (exist != null)
            {
                if (el == null)
                {
                    exist.Remove();
                }
                else
                {
                    exist.ReplaceWith(el);
                }
            }
            else
            {
                WrappedElement.Add(el);
            }
        }

        public override string ToString()
        {
            return WrappedElement.ToString();
        }

        #region ATTR

        public T GetAttr<T>(string attrName) where T : JetMap
        {
            string val = WrappedElement.Attribute(attrName).Value;
            var map = (T) Activator.CreateInstance(typeof (T), val);
            return map;
        }

        public void SetAttr(string attrName, JetMap map)
        {
            WrappedElement.SetAttributeValue(attrName, map.Wrapped);
        }

        #endregion
    }
}