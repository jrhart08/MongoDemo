using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MongoDemo.Data.Entities.Forms
{
    public class RecordedForm
    {
        public ObjectId Id { get; set; }

        [BsonElement("formId")]
        public ObjectId FormId { get; set; }

        [BsonElement("recorderName")]
        public string RecorderName { get; set; }

        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }

        [BsonElement("answers")]
        public List<Answer> Answers { get; set; }

        public class Answer
        {
            [BsonElement("_id")]
            public string ShortId { get; set; }

            [BsonElement("questionId")]
            public string QuestionId { get; set; }

            [BsonElement("answer")]
            public string AnswerText { get; set; }
        }
    }
}
