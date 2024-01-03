﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace versioning.Models
{
    public class EmployeeV2
    {
        /// <summary>
        /// Gets or sets the unique identifier for the employee.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the Gender of the employee .
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the city where the employee is located.
        /// </summary>


        public string City { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee is currently active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}