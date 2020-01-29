using System;
using System.Collections.Generic;

namespace CodesTable.Data
{
    public class Constants
    {
        public enum DBCommandType { SQL = 1, VIEW = 2, SPROC = 3 };
        public enum CategoryType { SIZE = 1, UOM = 2, COLOR = 3, PROJECT_TYPE = 4, STATUS = 5 }
    }

    //Helper method for CategoryType
    public static class CategoryTypeHelper
    {
        public static ICollection<CodeCategory> ToPickList()
        {
            ICollection<CodeCategory> list = new List<CodeCategory>();

            foreach (Constants.CategoryType c in (Constants.CategoryType[])Enum.GetValues(typeof(Constants.CategoryType)))
            {
                list.Add(new CodeCategory()
                {
                    Id = c.Value(),
                    Name = c.Description()
                });

            }
            return list;
        }
    }

    //Extension methods for CategoryType ENUM
    public static class CategoryTypeExtensions
    {
        public static string Description(this Constants.CategoryType type)
        {
            string typeString = String.Empty;
            switch (type)
            {
                case Constants.CategoryType.SIZE:
                    typeString = "Size";
                    break;
                case Constants.CategoryType.UOM:
                    typeString = "UOM";
                    break;
                case Constants.CategoryType.COLOR:
                    typeString = "Color";
                    break;
                case Constants.CategoryType.PROJECT_TYPE:
                    typeString = "Project Type";
                    break;
                case Constants.CategoryType.STATUS:
                    typeString = "Status";
                    break;
            }

            return $"{typeString}";
        }

        public static int Value(this Constants.CategoryType type)
        {
            int value = 0;
            switch (type)
            {
                case Constants.CategoryType.SIZE:
                    value = Convert.ToInt32(Constants.CategoryType.SIZE.ToString("d"));
                    break;
                case Constants.CategoryType.UOM:
                    value = Convert.ToInt32(Constants.CategoryType.UOM.ToString("d"));
                    break;
                case Constants.CategoryType.COLOR:
                    value = Convert.ToInt32(Constants.CategoryType.COLOR.ToString("d"));
                    break;
                case Constants.CategoryType.PROJECT_TYPE:
                    value = Convert.ToInt32(Constants.CategoryType.PROJECT_TYPE.ToString("d"));
                    break;
                case Constants.CategoryType.STATUS:
                    value = Convert.ToInt32(Constants.CategoryType.STATUS.ToString("d"));
                    break;
            }

            return value;
        }

    }
}
