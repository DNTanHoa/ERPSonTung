﻿using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface ITrainingCourseRepository : IRepository<TrainingCourse>
    {
        public bool IsExistCode(string Code);
    }
}
