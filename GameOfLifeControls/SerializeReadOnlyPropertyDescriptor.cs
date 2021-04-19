using System;
using System.Collections;
using System.ComponentModel;

namespace GameOfLifeControls
{
    internal sealed class SerializeReadOnlyPropertyDescriptor : PropertyDescriptor
    {
        #region Fields
        private PropertyDescriptor _pd = null;
        #endregion

        #region Properties
        public override AttributeCollection Attributes
        {
            get { return AppendAttributeCollection(this._pd.Attributes, ReadOnlyAttribute.Yes); }
        }

        public override Type ComponentType
        {
            get { return this._pd.ComponentType; }
        }

        public override TypeConverter Converter
        {
            get { return this._pd.Converter; }
        }

        public override bool IsReadOnly
        {
            get { return true; }
        }

        public override Type PropertyType
        {
            get { return this._pd.PropertyType; }
        }
        #endregion

        #region Constructor
        public SerializeReadOnlyPropertyDescriptor(PropertyDescriptor pd) : base(pd)
        {
            this._pd = pd;
        }
        #endregion

        #region Methods
        public override object GetEditor(Type editorBaseType)
        {
            return this._pd.GetEditor(editorBaseType);
        }

        public override bool CanResetValue(object component)
        {
            return this._pd.CanResetValue(component);
        }

        public override object GetValue(object component)
        {
            return this._pd.GetValue(component);
        }

        public override void ResetValue(object component)
        {
            this._pd.ResetValue(component);
        }

        public override void SetValue(object component, object value)
        {
            this._pd.SetValue(component, value);
        }

        public override bool ShouldSerializeValue(object component)
        {
            bool result = this._pd.ShouldSerializeValue(component);
            if (!result)
            {
                DefaultValueAttribute dva = (DefaultValueAttribute)_pd.Attributes[typeof(DefaultValueAttribute)];
                result = dva != null ? !Object.Equals(this._pd.GetValue(component), dva.Value) : true;
            }
            return result;
        }

        protected override void FillAttributes(IList attributeList)
        {
            attributeList.Add(ReadOnlyAttribute.Yes);
        }

        #region Static Methods
        static public AttributeCollection AppendAttributeCollection(AttributeCollection existing, params Attribute[] newAttrs)
        {
            return new AttributeCollection(AppendAttributes(existing, newAttrs));
        }
        static public Attribute[] AppendAttributes(AttributeCollection existing, params Attribute[] newAttrs)
        {
            if (existing == null)
                throw new ArgumentNullException(nameof(existing));
            if (newAttrs == null)
                newAttrs = new Attribute[0];
            Attribute[] attributes;
            Attribute[] newArray = new Attribute[existing.Count + newAttrs.Length];
            int actualCount = existing.Count;
            existing.CopyTo(newArray, 0);
            for (int idx = 0; idx < newAttrs.Length; idx++)
            {
                if (newAttrs[idx] == null)
                    throw new ArgumentNullException("newAttrs");
                bool match = false;
                for (int existingIdx = 0; existingIdx < existing.Count; existingIdx++)
                {
                    if (newArray[existingIdx].TypeId.Equals(newAttrs[idx].TypeId))
                    {
                        match = true;
                        newArray[existingIdx] = newAttrs[idx];
                        break;
                    }
                }
                if (!match)
                    newArray[actualCount++] = newAttrs[idx];
            }
            if (actualCount < newArray.Length)
            {
                attributes = new Attribute[actualCount];
                Array.Copy(newArray, 0, attributes, 0, actualCount);
            }
            else
            {
                attributes = newArray;
            }
            return attributes;
        }
        #endregion
        #endregion
    }
}
