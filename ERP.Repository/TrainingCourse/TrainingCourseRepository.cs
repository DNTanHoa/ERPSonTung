using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class TrainingCourseRepository : Repository<TrainingCourse>, ITrainingCourseRepository
    {
        public TrainingCourseRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        public bool IsExistCode(string Code)
        {
            var trainingCourse = context.TrainingCourse.Where(item => item.Code.Equals(Code)).FirstOrDefault();
            return trainingCourse != null ? true : false;
        }
    }
}
