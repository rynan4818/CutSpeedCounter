using CountersPlus.Counters.Custom;
using CountersPlus.Counters.Interfaces;
using System.Globalization;
using TMPro;
using CutSpeedCounter.Configuration;
using UnityEngine;

namespace CutSpeedCounter
{
    class CutSpeedCounter : BasicCustomCounter, INoteEventHandler
    {
        public int _notesLeft = 0;
        public int _notesRight = 0;

        public double _averageLeft = 0;
        public double _averageRight = 0;

        private float x = PluginConfig.Instance.OffsetX;
        private float y = PluginConfig.Instance.OffsetY;
        private float z = PluginConfig.Instance.OffsetZ;

        private TMP_Text _counterLeft;
        private TMP_Text _counterRight;
        public override void CounterInit()
        {
            string defaultValue = FormatCutSpeed(0);
            if (PluginConfig.Instance.EnableLabel) {
                var label = CanvasUtility.CreateTextFromSettings(Settings, new Vector3(x, y, z));
                label.text = "Average Cut Speed";
                label.fontSize = PluginConfig.Instance.LabelFontSize;
            }
            Vector3 leftOffset = new Vector3(x, y - 0.2f, z);
            TextAlignmentOptions leftAlign = TextAlignmentOptions.Top;
            if (PluginConfig.Instance.SeparateSaber) {
                _counterRight = CanvasUtility.CreateTextFromSettings(Settings, new Vector3(x + 0.2f, y - 0.2f, z));
                _counterRight.lineSpacing = -26;
                _counterRight.fontSize = PluginConfig.Instance.FigureFontSize;
                _counterRight.text = defaultValue;
                _counterRight.alignment = TextAlignmentOptions.TopLeft;

                leftOffset = new Vector3(x - 0.2f, y - 0.2f, z);
                leftAlign = TextAlignmentOptions.TopRight;
            }
            _counterLeft = CanvasUtility.CreateTextFromSettings(Settings, leftOffset);
            _counterLeft.lineSpacing = -26;
            _counterLeft.fontSize = PluginConfig.Instance.FigureFontSize;
            _counterLeft.text = defaultValue;
            _counterLeft.alignment = leftAlign;
        }
        public void OnNoteCut(NoteData noteData, NoteCutInfo noteCutInfo)
        {
            if (noteData.colorType == ColorType.None || !noteCutInfo.allIsOK) return;
            if (noteCutInfo.saberType == SaberType.SaberA) {
                var x = _averageLeft * _notesLeft + (noteCutInfo.saberSpeed * 3.6d);
                this._notesLeft++;
                _averageLeft = x / _notesLeft;
            } else {
                var x = _averageRight * _notesRight + (noteCutInfo.saberSpeed * 3.6d);
                this._notesRight++;
                _averageRight = x / _notesRight;
            }
            if (PluginConfig.Instance.SeparateSaber) {
                _counterLeft.text = FormatCutSpeed(_averageLeft);
                _counterRight.text = FormatCutSpeed(_averageRight);
            }
            else {
                var average = (_averageLeft + _averageRight) * 0.5d;
                _counterLeft.text = FormatCutSpeed(average);
            }
        }

        public void OnNoteMiss(NoteData noteData)
        {
        }
        private string FormatCutSpeed(double cutSpeed)
        {
            return cutSpeed.ToString($"F{PluginConfig.Instance.DecimalPrecision}", CultureInfo.InvariantCulture);
        }
        public override void CounterDestroy()
        {
        }

    }
}
