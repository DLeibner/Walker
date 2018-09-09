using System;

namespace Walker
{
  public class NotificationEventArgs : EventArgs
  {
    public string Message { get; private set; }

    public NotificationEventArgs(string message)
    {
      Message = message;
    }
  }
}
