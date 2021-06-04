 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_ISP
{
    interface IVehicleDocumentation
    {
        void ChangeOwner(string newName);
        string GetOwner();
        void PassInspection(string newInspectionDate);
        string GetInspectionDate();
    }
}
