using System;
using System.Collections.Generic;
using System.Text;

namespace Misa_MF736_HqMinh_Common.Models
{
    public class Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Required : System.Attribute
    {
        public String propertyName;
        public String errorMessage;
        public Required(String propertyName, String errorMessage = null)
        {
            this.propertyName = propertyName;
            this.errorMessage = errorMessage;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : System.Attribute
    {
        public String propertyName;
        public String errorMessage;
        public CheckDuplicate(String propertyName, String errorMessage = null)
        {
            this.propertyName = propertyName;
            this.errorMessage = errorMessage;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CheckLenght : System.Attribute
    {
        public String propertyName;
        public int max;
        public String errorMessage;
        public CheckLenght(String propertyName, int max, String errorMessage = null)
        {
            this.propertyName = propertyName;
            this.errorMessage = errorMessage;
            this.max = max;
        }
    }   
}
