using Content.Shared._Trauma.Phones.Components;
using Robust.Client.UserInterface;

namespace Content.Client._Trauma.Phones.UI;

public sealed partial class PhoneNameChangeUI : BoundUserInterface
{
    private ChangePhoneName? _menu;

    public PhoneNameChangeUI(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {
    }

    protected override void Open()
    {
        base.Open();

        _menu = this.CreateWindow<ChangePhoneName>();

        _menu.OnTextChanged += i =>
        {
            SendPredictedMessage(new PhoneNameChangedMessage(i));
        };
        _menu.OnCategoryChanged += i =>
        {
            SendPredictedMessage(new PhoneCategoryChangedMessage(i));
        };
    }
}
