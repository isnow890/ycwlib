using System;
using System.Linq;

namespace ChanWooLib.MethodExtension
{
    public static class ReflectionExtension
    {
        public static object GetPropertyValue(this object car, string propertyName)
        {
            return car.GetType().GetProperties()
               .Single(pi => pi.Name == propertyName)
               .GetValue(car, null);
        }


        public static T GetCloneVariable<T>(T t)
        {
            var propertyInfos = typeof(T).GetProperties();
            var dub1 = Activator.CreateInstance(typeof(T));

            foreach (var propertyInfo in propertyInfos)
            {
                if (!(propertyInfo.Name is "Item"))
                { 
                    var prop = dub1.GetType().GetProperty(propertyInfo.Name);
                    prop.SetValue(dub1, (GetPropertyValue(t, propertyInfo.Name)), null);
                }
            }

            return (T)Convert.ChangeType(dub1, typeof(T));
        }



        /// <summary>
        /// 두 dto 값복사                     model.DB = MappingVariables(model.DB, ucPt_no.model.SelectPatientInfoOutObj);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="org"></param>
        /// <param name="copy"></param>
        /// <returns></returns>
        public static T MappingVariables<T, T1>(T org, T1 copy, string[] _lst = null)
        {
            foreach (var copy_prop in typeof(T1).GetProperties())
            {
                foreach (var org_prop in typeof(T).GetProperties())
                    if (!(copy_prop.Name is "Item") && (copy_prop.Name == org_prop.Name) && (copy_prop.GetType() == org_prop.GetType()))
                    {
                        try
                        {
                            if (_lst is null)
                            {
                                var tmp = org.GetType().GetProperty(org_prop.Name);
                                if (tmp.CanWrite)
                                    tmp.SetValue(org, GetPropertyValue(copy, copy_prop.Name), null);
                            }
                            else
                                foreach (var xx in _lst)
                                    if (string.Compare(copy_prop.Name, xx.Trim()) is 0)
                                    {
                                        var tmp = org.GetType().GetProperty(org_prop.Name);
                                        if (tmp.CanWrite)
                                            tmp.SetValue(org, GetPropertyValue(copy, copy_prop.Name), null);
                                    }
                        }
                        catch (Exception) { }
                    }
            }
            return (T)Convert.ChangeType(org, typeof(T));
        }



    }



}


