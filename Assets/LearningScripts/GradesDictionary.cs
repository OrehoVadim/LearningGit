using System.Collections.Generic;

namespace LearningScripts
{
    public class GradesDictionaryClass
    {
        private Dictionary<int, char> GradesDictionary;

        public void GradesDictionaryHandler(int ID, char Grade)
        {
            GradesDictionary[ID] = Grade;
        }
    }
}