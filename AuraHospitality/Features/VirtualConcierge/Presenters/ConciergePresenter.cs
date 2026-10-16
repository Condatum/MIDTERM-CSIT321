using AuraHospitality.Features.VirtualConcierge.Models;
using AuraHospitality.Features.VirtualConcierge.Services;

namespace AuraHospitality.Features.VirtualConcierge.Presenters;

public interface IConciergeView
{
    void DisplayMessages(IReadOnlyList<ConciergeMessage> messages);
    void ClearInput();
}

public class ConciergePresenter
{
    private readonly IConciergeService _service;
    private IConciergeView? _view;

    public string CurrentInput { get; set; } = string.Empty;

    public ConciergePresenter(IConciergeService service)
    {
        _service = service;
        _service.OnMessagesChanged += HandleMessagesChanged;
    }

    public void AttachView(IConciergeView view)
    {
        _view = view;
        RefreshMessages();
    }

    private void HandleMessagesChanged()
    {
        RefreshMessages();
    }

    private void RefreshMessages()
    {
        _view?.DisplayMessages(_service.GetHistory());
    }

    public void SendMessage(string? explicitText = null)
    {
        var text = explicitText ?? CurrentInput;
        if (string.IsNullOrWhiteSpace(text)) return;

        _service.SendUserMessage(text.Trim());
        CurrentInput = string.Empty;
        _view?.ClearInput();
    }
}
