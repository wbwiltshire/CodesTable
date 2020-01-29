using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CodesTable.Data;
using CodesTable.Data.Interfaces;
using System.Reflection;

namespace CodesTable.Data.POCO
{
    public class CodeCategory
    {
        #region Static Properties and Helpers
        [Display(Name = "Size")]
        public static int SIZE { get { return 1; } }
        [Display(Name = "UOM")]
        public static int UOM { get { return 2; } }
        [Display(Name = "Color")]
        public static int COLOR { get { return 3; } }
        [Display(Name = "Project Type")]
        public static int PROJECT_TYPE { get { return 4; } }
        [Display(Name = "Status")]
        public static int STATUS { get { return 5; } }
        private static Type TYPE { get { return typeof(CodeCategory); } }
        public static string GetDisplayName(string name)
        {
            MemberInfo property = TYPE.GetProperty(name);
            DisplayAttribute attribute = (DisplayAttribute)property.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault();
            return (attribute != null) ? attribute.Name : "";
        }
        public static ICollection<CodeCategory> GetList()
        {
            return new List<CodeCategory>()
            {
                new CodeCategory() { Id = SIZE, Name = GetDisplayName("SIZE") },
                new CodeCategory() { Id = UOM, Name = GetDisplayName("UOM") },
                new CodeCategory() { Id = COLOR, Name = GetDisplayName("COLOR") },
                new CodeCategory() { Id = PROJECT_TYPE, Name = GetDisplayName("PROJECT_TYPE") },
                new CodeCategory() { Id = STATUS, Name = GetDisplayName("STATUS")}
            };
        }
        #endregion

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
