namespace Todo.me.Model
{
    public class SprintModel
    {
        private SprintTable _sprinttable;

        public SprintTable Sprinttable
        {
            get => _sprinttable; 
            set
            {
                _sprinttable = value;
            }
        }

        public SprintModel(SprintTable sprint = null)
        {
            Sprinttable = sprint != null ? sprint : new SprintTable();
        }
        public int Id
        {
            get => Sprinttable.Id;
        }

        public int SprintDuration
        {
            get => Sprinttable.SprintDuration;
            set
            {
                Sprinttable.SprintDuration = value;
            }
        }

        public List<TodoTable> TodoItems
        {
            get => Sprinttable.TodoItems;
        }

    }
}
