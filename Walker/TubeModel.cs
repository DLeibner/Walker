namespace Walker
{
  public sealed class TubeModel : PropertyChangedNotifier
  {
    private int _row;

    public int Row
    {
      get => _row;
      set
      {
        _row = value;
        RaisePropertyChanged("Row");
      }
    }

    private int _column;

    public int Column
    {
      get => _column;
      set
      {
        _column = value;
        RaisePropertyChanged("Column");
      }
    }

    private string _status;

    public string Status
    {
      get => _status;
      set
      {
        _status = value;
        RaisePropertyChanged("Status");
      }
    }
  }
}
