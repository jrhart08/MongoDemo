using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MongoDemo.Data.Entities.Forms
{
    public class Form
    {
        // BSON id
        public ObjectId Id { get; set; }

        [BsonElement("formLinkId")]
        public string FormLinkId { get; set; }

        [BsonElement("formName")]
        public string FormName { get; set; }

        [BsonElement("formType")]
        public string FormType { get; set; }

        [BsonElement("revision")]
        public int Revision { get; set; }

        [BsonElement("sections")]
        public List<Section> Sections { get; set; }

        /// <summary>
        /// <para>All other metadata.</para>
        /// <para>A common convention is to attach any non-structured data onto a 'metadata' property like this.</para>
        /// <para>Alternatively, we can add the [BsonExtraElements] attribute if we're just splatting all other metadata onto the object.</para>
        /// </summary>
        [BsonElement("metadata")]
        public BsonDocument Metadata { get; set; }

        public class Section
        {
            [BsonElement("sectionName")]
            public string SectionName { get; set; }
            
            [BsonElement("questions")]
            public List<Question> Questions { get; set; }
        }

        public class Question
        {
            [BsonElement("question")]
            public string QuestionText { get; set; }

            [BsonElement("type")]
            public string Type { get; set; }
        }
    }
}
