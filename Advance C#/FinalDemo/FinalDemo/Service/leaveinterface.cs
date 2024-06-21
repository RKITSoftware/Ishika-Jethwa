using System.Collections.Generic;

namespace FinalDemo.Service
{
    public interface leaveinterface<T>
    {   
        List<T> GetAllLeave();

        T GetLeaveRequestById(int id);

        List<T> SubmitLeaveRequest(T request);

        string ApproveRejectLeaveRequest(int id ,string status);

    }
}