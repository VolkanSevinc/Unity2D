using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Dialog
    {
        private List<Dialog> subDialogList;
        private string[] dialogLines;

        public Dialog(List<Dialog> subDialogList, string[] dialogLines)
        {
            this.subDialogList = subDialogList;
            this.dialogLines = dialogLines;
        }


        public Dialog selectChild(int childIndex)
        {
            return subDialogList[childIndex];
        }

        public List<Dialog> SubDialogList
        {
            get => subDialogList;
            set => subDialogList = value;
        }

        public string[] DialogLines
        {
            get => dialogLines;
            set => dialogLines = value;
        }
    }
}