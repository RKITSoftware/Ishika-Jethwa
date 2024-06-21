using Birth_Certificate_Generator.BL.Handler;
using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.Connection;
using Birth_Certificate_Generator.DL.Context;
using Birth_Certificate_Generator.DL.Interface;
using System.Configuration;
using System.Reflection;

namespace Birth_Certificate_Generator.Other
{
    /// <summary>
    /// static class Convertor with extension method
    /// </summary>
    public static class Convertor
    {
        #region Public Methods

        /// <summary>
        /// Creates an instance of the target type and maps properties from the source object to the target object.
        /// </summary>
        /// <typeparam name="T">The type of object to create.</typeparam>
        /// <param name="objSource">The source object from which property values will be retrieved.</param>
        /// <returns>An instance of the target type with properties mapped from the source object.</returns>
        public static T CreatePOCO<T>(this object objSource)
        {
            Type sourceType = objSource.GetType();
            Type targetType = typeof(T);

            T objTarget = (T)Activator.CreateInstance(targetType);

            PropertyInfo[] lstSourceProp = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo sourceProp in lstSourceProp)
            {
                string propName = sourceProp.Name;
                PropertyInfo targetProp = targetType.GetProperty(propName);
                if (targetProp != null)
                {
                    object propValue = sourceProp.GetValue(objSource);
                    targetProp.SetValue(objTarget, propValue);
                }
            }
            return objTarget;
        }


        /// <summary>
        /// Gets the corresponding message for the enum value.
        /// </summary>
        /// <param name="enumValue">The enum value.</param>
        /// <returns>The message corresponding to the enum value.</returns>
        public static string GetMessage(this EnmOperation enumValue)
        {
            switch (enumValue)
            {
                case EnmOperation.I:
                    return "Record inserted successfully.";
                case EnmOperation.D:
                    return "Record deleted successfully.";
                case EnmOperation.U:
                    return "Record updated successfully.";
                default:
                    return "Unknown operation.";
            }
        }

        public static IServiceCollection MyServices(this IServiceCollection services,  IConfiguration configuration)
        {
            // Registering email service
            services.AddScoped<IEmailService, BLEmailHandler>();

            // Registering business logic handlers and data contexts
            services.AddScoped<IUSR01, BLUSR01Handler>();
            services.AddScoped<IUSR01Repository, DBUSR01Context>();
            services.AddScoped<IBCR01, BLBCR01Handler>();
            services.AddScoped<IBCR01Repository, DBBCR01Context>();
            services.AddScoped<IBCT01, BLBCT01Handler>();
            services.AddScoped<ICHD01, BLCHD01Handler>();
            services.AddScoped<ICHD01Repository, DBCHD01Context>();
            services.AddSingleton<IOrmLiteContext>(provider =>
               new OrmLiteContext(configuration.GetConnectionString("Default")));
            return services;
        }

      
        #endregion
    }
}
