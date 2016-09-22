using Newtonsoft.Json;

namespace ProcessServer
{
    public class RequestObject
    {

        string _action;
        string _path;
        string _args;

        #region accessors
        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public string Args
        {
            get { return _args; }
            set { _args = value; }
        }
        #endregion accessors

        public RequestObject(string jsonString)
        {

        }
    }

    public class ResponseObject
    {
        #region private members
        int _id;
        string _name;
        string _message;
        string _status;
        bool? _success;
        #endregion private members

        #region accessors
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

        public bool? Success
        {
            get
            {
                return _success;
            }

            set
            {
                _success = value;
            }
        }
        #endregion accessors

        public ResponseObject(int id, string name, string message, string status, bool? success)
        {
            this.Id = id;
            this.Name = name;
            this.Message = message;
            this.Status = status;
            this.Success = success;
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
