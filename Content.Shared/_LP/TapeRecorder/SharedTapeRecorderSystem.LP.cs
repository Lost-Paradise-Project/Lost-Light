using Content.Shared._Starlight.TapeRecorder.Components;
using Content.Shared.Speech;
using Robust.Shared.Prototypes;

namespace Content.Shared._Starlight.TapeRecorder;

/// <summary>
/// Запись на кассету из кода: так пишут автоответчик и жучок, которых никто не слушает ушами.
/// </summary>
public abstract partial class SharedTapeRecorderSystem
{
    /// <summary>
    /// В диктофоне есть кассета, и на ней осталось место.
    /// </summary>
    public bool CanRecord(Entity<TapeRecorderComponent> recorder)
    {
        return TryGetTapeCassette(recorder, out var tape)
            && tape.Comp.CurrentPosition < tape.Comp.MaxCapacity.TotalSeconds;
    }

    /// <summary>
    /// Включает запись без звуков: диктофон, спрятанный в телефоне, не должен щёлкать.
    /// Лента идёт, пока запись не остановят.
    /// </summary>
    public bool TryStartRecording(Entity<TapeRecorderComponent> recorder)
    {
        if (!CanRecord(recorder))
            return false;

        if (recorder.Comp.Mode == TapeRecorderMode.Recording)
            return true;

        SetModeSilent(recorder, TapeRecorderMode.Recording);
        return true;
    }

    public void StopRecording(Entity<TapeRecorderComponent> recorder)
    {
        if (recorder.Comp.Mode != TapeRecorderMode.Recording)
            return;

        SetModeSilent(recorder, TapeRecorderMode.Stopped);
    }

    /// <summary>
    /// Дописывает реплику на кассету в текущую позицию ленты. Запись должна быть включена.
    /// </summary>
    public bool TryRecordMessage(Entity<TapeRecorderComponent> recorder, string name, ProtoId<SpeechVerbPrototype> verb, string message, string? voiceId)
    {
        if (recorder.Comp.Mode != TapeRecorderMode.Recording || !TryGetTapeCassette(recorder, out var tape))
            return false;

        tape.Comp.Buffer.Add(new TapeCassetteRecordedMessage(tape.Comp.CurrentPosition, name, verb, message, voiceId));
        return true;
    }

    private void SetModeSilent(Entity<TapeRecorderComponent> recorder, TapeRecorderMode mode)
    {
        if (mode == TapeRecorderMode.Stopped)
            RemComp<ActiveTapeRecorderComponent>(recorder);
        else
            EnsureComp<ActiveTapeRecorderComponent>(recorder);

        recorder.Comp.Mode = mode;
        Dirty(recorder);
        UpdateAppearance(recorder);
    }
}
