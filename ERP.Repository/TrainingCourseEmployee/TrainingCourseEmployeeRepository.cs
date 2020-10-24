using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class TrainingCourseEmployeeRepository : Repository<TrainingCourseEmployee>, ITrainingCourseEmployeeRepository
    {
        public TrainingCourseEmployeeRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        
    }
}
