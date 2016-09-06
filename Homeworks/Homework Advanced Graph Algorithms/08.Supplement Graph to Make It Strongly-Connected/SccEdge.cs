namespace _08.Supplement_Graph_to_Make_It_Strongly_Connected
{
    public class SccEdge
    {
        public SccEdge(int parentScc, int childScc)
        {
            this.ParentScc = parentScc;
            this.ChildScc = childScc;
        }

        public int ChildScc { get; set; }

        public int ParentScc { get; set; }
    }
}