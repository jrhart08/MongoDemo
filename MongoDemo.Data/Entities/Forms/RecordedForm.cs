using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDemo.Data.Entities.Forms
{
    public class RecordedForm
    {
        public ObjectId Id { get; set; }
        public ObjectId FormId { get; set; }
        public string RecorderName { get; set; }

        public List<Answer> Answers { get; set; }

        public class Answer
        {
            public string Question { get; set; }
            public string AnswerText { get; set; }
        }
    }
}
