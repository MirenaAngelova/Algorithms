using System.Collections.Generic;
using System.Linq.Expressions;

namespace _08.Supplement_Graph_to_Make_It_Strongly_Connected
{
    public class ConnectedComponent
    {
        public ConnectedComponent(List<int> members, int membersCount)
        {
            this.Members = new List<int>(members);
            this.MembersCount = membersCount;
        }

        public int MembersCount { get; set; }

        public List<int> Members { get; set; }
    }
}