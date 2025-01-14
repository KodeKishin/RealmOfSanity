using System;
using System.Collections.Generic;

namespace Unity.Properties
{
    public struct ListProperty<TContainer, TElement> : ICollectionProperty<TContainer, IList<TElement>>
    {
        private struct CollectionElementProperty : ICollectionElementProperty<TContainer, TElement>
        {
            private readonly ListProperty<TContainer, TElement> m_Property;
            private readonly IPropertyAttributeCollection m_Attributes;
            private readonly int m_Index;

            public string GetName() => "[" + Index + "]";
            public bool IsReadOnly => false;
            public bool IsContainer => RuntimeTypeInfoCache<TElement>.IsContainerType();
            public IPropertyAttributeCollection Attributes => m_Attributes;
            public int Index => m_Index;

            public CollectionElementProperty(ListProperty<TContainer, TElement> property, int index, IPropertyAttributeCollection attributes = null)
            {
                m_Property = property;
                m_Attributes = attributes;
                m_Index = index;
            }

            public TElement GetValue(ref TContainer container)
            {
                return m_Property.m_Getter(ref container)[Index];
            }

            public void SetValue(ref TContainer container, TElement value)
            {
                m_Property.m_Getter(ref container)[Index] = value;
            }
        }

        public delegate IList<TElement> Getter(ref TContainer container);
        public delegate void Setter(ref TContainer container, IList<TElement> value);

        private readonly string m_Name;
        private readonly Getter m_Getter;
        private readonly Setter m_Setter;
        private readonly IPropertyAttributeCollection m_Attributes;

        public string GetName() => m_Name;
        public bool IsReadOnly => false;
        public bool IsContainer => false;
        public IPropertyAttributeCollection Attributes => m_Attributes;

        public ListProperty(string name, Getter getter, Setter setter, IPropertyAttributeCollection attributes = null)
        {
            m_Name = name;
            m_Getter = getter;
            m_Setter = setter;
            m_Attributes = attributes;

            if (RuntimeTypeInfoCache<TElement>.IsArray())
            {
                throw new Exception("ArrayProperty`2 does not support array of array");
            }
        }

        public IList<TElement> GetValue(ref TContainer container)
        {
            return m_Getter(ref container);
        }

        public void SetValue(ref TContainer container, IList<TElement> value)
        {
            m_Setter(ref container, value);
        }

        public int GetCount(ref TContainer container)
        {
            return m_Getter(ref container)?.Count ?? 0;
        }

        public void SetCount(ref TContainer container, int count)
        {
            throw new NotImplementedException();
        }

        public void Clear(ref TContainer container)
        {
            if (null == m_Getter(ref container))
            {
                return;
            }

            m_Setter(ref container, new TElement[0]);
        }

        public void GetPropertyAtIndex<TGetter>(ref TContainer container, int index, ref ChangeTracker changeTracker, TGetter getter)
            where TGetter : ICollectionElementGetter<TContainer>
        {
            getter.VisitProperty<CollectionElementProperty, TElement>(new CollectionElementProperty(this, index), ref container);
        }
    }
}
