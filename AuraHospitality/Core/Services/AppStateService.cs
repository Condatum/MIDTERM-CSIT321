using AuraHospitality.Core.Models;

namespace AuraHospitality.Core.Services;

public interface IAppStateService
{
    AppViewMode ViewMode { get; }
    string GuestNavTab { get; }
    string PmsNavTab { get; }
    bool IsTripsDrawerOpen { get; }
    bool IsConciergeOpen { get; }
    IReadOnlyList<NotificationMessage> Notifications { get; }

    event Action? OnStateChanged;
    event Action? OnConfettiRequested;

    void SetViewMode(AppViewMode mode);
    void SetGuestNavTab(string tab);
    void SetPmsNavTab(string tab);
    void ToggleTripsDrawer(bool? open = null);
    void ToggleConcierge(bool? open = null);
    void PushNotification(string title, string message, NotificationType type = NotificationType.Info);
    void DismissNotification(string id);
    void RequestConfetti();
}

public class AppStateService : IAppStateService
{
    private readonly List<NotificationMessage> _notifications = new();

    public AppViewMode ViewMode { get; private set; } = AppViewMode.GuestExperience;
    public string GuestNavTab { get; private set; } = "stays";
    public string PmsNavTab { get; private set; } = "overview";
    public bool IsTripsDrawerOpen { get; private set; }
    public bool IsConciergeOpen { get; private set; }
    public IReadOnlyList<NotificationMessage> Notifications => _notifications.AsReadOnly();

    public event Action? OnStateChanged;
    public event Action? OnConfettiRequested;

    public void SetViewMode(AppViewMode mode)
    {
        ViewMode = mode;
        Notify();
    }

    public void SetGuestNavTab(string tab)
    {
        GuestNavTab = tab;
        Notify();
    }

    public void SetPmsNavTab(string tab)
    {
        PmsNavTab = tab;
        Notify();
    }

    public void ToggleTripsDrawer(bool? open = null)
    {
        IsTripsDrawerOpen = open ?? !IsTripsDrawerOpen;
        Notify();
    }

    public void ToggleConcierge(bool? open = null)
    {
        IsConciergeOpen = open ?? !IsConciergeOpen;
        Notify();
    }

    public void PushNotification(string title, string message, NotificationType type = NotificationType.Info)
    {
        var item = new NotificationMessage(Guid.NewGuid().ToString(), title, message, type);
        _notifications.Insert(0, item);
        if (_notifications.Count > 5)
        {
            _notifications.RemoveAt(_notifications.Count - 1);
        }
        Notify();
    }

    public void DismissNotification(string id)
    {
        _notifications.RemoveAll(n => n.Id == id);
        Notify();
    }

    public void RequestConfetti()
    {
        OnConfettiRequested?.Invoke();
    }

    private void Notify() => OnStateChanged?.Invoke();
}
