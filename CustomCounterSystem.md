����́ACountersPlus��Wiki�ɂ���[Custom Counter System](https://github.com/Caeden117/CountersPlus/wiki/For-Developers#custom-counter-system)�̐�����mod�쐬�̎Q�l�ɂ��邽�߂ɁA���{��󂵂����̂ł��B

www.DeepL.com/Translator�i�����Łj�Ŗ|�󂵂܂����B

---------------------------------------------------------------------------------------
# Custom Counter System

Counters+�ɓƎ��̃J�E���^�[��ǉ��������Ǝv�������Ƃ�����܂����A�����Ǝ��̃X�^���h�A���[��MOD�ɂ������Ǝv�������Ƃ͂���܂��񂩁HCounters+�ɂ́A�C�ӂ̃J�E���^��Counters+�V�X�e���ɊȒP�Ɏ������邱�Ƃ��ł���\�����[�V����������܂��B

UI�G���n���X�����gMOD���쐬����J���҂́A���[�U�[�����Ȃ���MOD�ƏՓ˂���ݒ�����Ă���\��������̂ŁACounters+�̓������������Ă��������B

### �ˑ����邩���Ȃ����H

�J�X�^���J�E���^�V�X�e���́ACounters+�ˑ����I�v�V�����ł���悤�ɐ݌v����Ă��܂����A**�n�[�hCounters+�ˑ��������Ƃ́A�J���҂̑��ŗe�ՂɂȂ�܂��B**
�n�[�h�Ȉˑ��֌W������΁ACounters+���C���X�g�[������Ă���ꍇ�Ƃ���Ă��Ȃ��ꍇ��2�̕ʁX�̃R�[�h���ێ����邱�Ƃ�S�z����K�v�͂���܂���B

## �͂��߂�
-------------------------------------------------------------------------------------
�܂��A�v���O�C���� `manifest.json` �t�@�C���ɃA�N�Z�X���܂��B

Counters+ 2.0.0�̃J�X�^���J�E���^�V�X�e���́ABSIPA 4.0.5�ȍ~�̃o�[�W�����œ������ꂽ�V����BSIPA Feature's�V�X�e�����g�p���Ă��܂��B
�K�v�ɉ����āA�ŐV��BSIPA�r���h����肷�邱�Ƃ��ł��܂��B

�ȉ��� `manifest.json` �Œ�`���ꂽ�J�X�^���J�E���^�̗�ł��B

    "features": {
      "CountersPlus.CustomCounter": {
        "Name": "Example Custom Counter",
        "CounterLocation": "ExampleCustomCounterMod.CustomCounter",
        "ConfigDefaults": {
          "Enabled": true,
          "Position": "AboveCombo",
          "Distance": 0
        },
        "BSML": {
          "Resource": "ExampleCustomCounterMod.TestCustomUI.bsml",
          "Host": "ExampleCustomCounterMod.TestCustomUIHost",
          "Icon": "ExampleCustomCounterMod.william_gay.png"
        }
      }
    }

�܂���`����Ă��Ȃ��ꍇ�́A�}�j�t�F�X�g��`Features`�I�u�W�F�N�g��ǉ����܂��B
�ȑO�Ƃ͈قȂ�A���̐V����Features�V�X�e���ł́A�z��ł͂Ȃ��I�u�W�F�N�g���g�p���܂��B
���̌�A���̉���`CountersPlus.CustomCounter`�Ƃ����V�����q�I�u�W�F�N�g���쐬�������Ǝv���܂��B

### Name (�K�{)
�J�X�^���J�E���^�[�̖��O�ł��B
Counters+�̐ݒ胁�j���[�ɕ\�������ق��A���܂��܂ȓ����R���|�[�l���g�̎��ʎq�Ƃ��Ă��g�p����܂��B
**���ӂ��Ă�������** �ŏ��̌��J��ɕύX���邱�Ƃ͂����߂ł��܂���̂ŁA�ǂ����O���l���Ă��������B

### Description#
���Ȃ��̃J�X�^���J�E���^�[�̐����ł��B���݂͖��g�p�ł��B

### CounterLocation (�K�{)
�����������J�X�^���J�E���^�̖��O��Ԃ̏ꏊ�ł��B����́A`MonoBehaviour`�ACounters+ Custom Counter�^�C�v���p�������N���X�A�܂��͂��̂�����ł��Ȃ����̂ł��B

**�C���X�^���X�쐬�̐S�z�͖��p�ł�!** Counters+�ł́AZenject���g�p���āA�Ȃ̓��͎��ɃJ�X�^���E�J�E���^�[�̃C���X�^���X�𐶐����܂��B����ɂ��A�J�X�^���E�J�E���^�[��Zenject���ő���Ɋ��p���邱�Ƃ��ł��܂��B

## ConfigDefaults
�J�E���^�̐ݒu�ꏊ�ɂ��ēƎ��̃f�t�H���g��񋟂������ꍇ�́A���̃I�u�W�F�N�g���I�[�o�[���C�h���Ă��������B�����`ConfigModel`�ŁA3�̕����ō\������Ă��܂��B

  * **Enabled**  ����́A���������L���ɂȂ��Ă��邩�ǂ����𐧌䂷����̂ł��B
  * **Position** ����́A"���ΓI�� "�|�C���g�ƂȂ镶����l��Enum�ł��B
    �L���ȃI�v�V������
    * `AboveCombo` and `BelowCombo`
    * `AboveMultiplier` and `BelowMultiplier`
    * `BelowEnergy`
    * `AboveHighway`
* **Distance** ����́A�����̑��ΓI�ȃ|�C���g����̃X�e�b�v�ŁA�ŏI�I�Ȉʒu�����肵�܂��B

### BSML
Counters+�ݒ胁�j���[�ł̓�����L�q����I�v�V�����̃I�u�W�F�N�g�ł��B�ݒ�I�v�V������J�X�^���A�C�R���̒񋟂�\�肵�Ă��Ȃ��ꍇ�́A���̃I�u�W�F�N�g���ȗ����邱�Ƃ��ł��܂��B

### Resource
����́A`ConfigModel`�̃I�v�V�����̉��ɕt�������`.bsml`�t�@�C���ւ̖��O��Ԃ̈ʒu�ł��B

����BSML�t�@�C���ł́ACounters+�Ƃ̐�������ۂ��߂ɁA���̃e���v���[�g���x�[�X�ɂ���UI���쐬���邱�Ƃ���������܂��B

    <vertical xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xsi:schemaLocation='https://monkeymanboy.github.io/BSML-Docs/ https://raw.githubusercontent.com/monkeymanboy/BSML-Docs/gh-pages/BSMLSchema.xsd' spacing='1' horizontal-fit='PreferredSize' vertical-fit='PreferredSize'>
        <!-- BSML goes here -->
    </vertical>

���̍��ڂ��󔒂ɂ��Ă��\���܂���B�󔒂ɂ����ꍇ�A�ǉ��̃R���e���c�i�܂��̓z�X�g�I�u�W�F�N�g�j�͒ǉ�����܂���B

### Host
����́A�񋟂��ꂽBSML�t�@�C���̂��ׂĂ�`UIValues`�A`UIActions`�A`UIEvents`����������Type�̖��O��Ԃ̈ʒu�ł��B

`CounterLocation`�Ɠ��l�ɁACounters+��Zenject�}�W�b�N���g���āA�K�v�Ȏ��ɂ��̃I�u�W�F�N�g�������I�ɍ쐬���܂��B
�܂��A���̃I�u�W�F�N�g�̒���Zenject���t�����p���邱�Ƃ��ł��܂��B

### Icon
����́A���ׂẴJ�E���^�[�̃��X�g�ɕ\�������f�t�H���g�̃J�X�^���J�E���^�[�A�C�R�����㏑������C���[�W�̃l�[���X�y�[�X�̈ʒu�ł��B

�T�|�[�g����Ă��邷�ׂẴt�@�C���`���ɂ��Ă͐��m�ɂ͂킩��܂��񂪁A`.png`�����삷�邱�Ƃ�100���A`.jpg`�����삷�邱�Ƃ�85���قǂł��B���̂��̂ŉ^�����͂��Ȃ��ق��������Ǝv���܂��B

## �J�E���^�[�̍쐬
-------------------------------------------------------------------------------------------------------------------
�ė��p������`MonoBehaviour`�����łɂ���ꍇ�́A�����`CounterLocation`�ɍ������߂΁ACounters+�͊��ł�����E���A�Q�[���Ƀ��[�h���Ă���܂��B
�������ACounters+ 2.0.0�̋@�\���\���Ɋ��p���邽�߂ɂ́A�J�X�^���J�E���^�[���ŏ�����쐬���邱�Ƃ������߂��܂��B

Counters+�ł́A`CountersPlus.Counters.Custom`���O��ԂŁA�J�X�^���J�E���g�����������邽�߂Ɍp���ł��邢�����̃p�u���b�N�N���X��񋟂��Ă��܂��B

## `BasicCustomCounter`
����́A�������̃��[�e�B���e�B�[�E�I�u�W�F�N�g�iZenject �Œ����j�Ƃ������̃��\�b�h��񋟂��邾���́A�K�v�Œ���̃J�X�^���E�J�E���^�[�E�N���X�ł��B

### CanvasUtility
`CanvasUtility`�́A���̃N���X���̃t�B�[���h�ŁACounters+�̃L�����o�X�Ɋ֘A����@�\�ɑf�����A�N�Z�X������A�e�L�X�g��f�����ȒP�ɐ������邱�Ƃ��ł��܂��B

### Settings
����́A�J�X�^���J�E���^�[�Ɏg�p�����`CustomConfigModel`�ł��B�����`CanvasUtility`�Ƒg�ݍ��킹�邱�ƂŁA������1�s�̃R�[�h�ŊȒP�ɃJ�X�^���e�L�X�g���쐬���邱�Ƃ��ł��܂��B

### CounterInit
CounterInit�́ACounters+���I�u�W�F�N�g�����[�h����Ƃ��ɌĂяo����钊�ۃ��\�b�h�ł��i�܂�A�I�[�o�[���C�h����K�v������܂��j�B���̃��\�b�h�ł́A�J�E���^�[�̃e�L�X�g���쐬������A�C�x���g���w�ǂ����肵�܂��B

### CounterDestroy
CounterDestroy�́A�I�u�W�F�N�g���j�󂳂ꂽ�Ƃ��ɌĂяo����钊�ۃ��\�b�h�ł��i�܂�A�I�[�o�[���C�h���Ȃ���΂Ȃ�܂���j�B�����ł́A�������g�̌�n���A�C�x���g�̍w�ǒ�~�AUnity�Ɏ����I�ɏE���Ȃ��\���̂�����̂̔j���Ȃǂ��s���܂��B

## `CanvasCustomCounter`
������Canvas���ǂ����Ă��ė��p�������ꍇ�́A���s�̒ǉ��R�[�h��Custom Counter���g���āACounters+�ɍĔz�u�����邱�Ƃ��ł��܂��B

����`CanvasCustomCounter`�N���X��`BasicCustomCounter`���p�����Ă���̂ŁA`Settings`�I�u�W�F�N�g��`CanvasUtility`�̂悤�ȃw���p�[��`CanvasCustomCounter`�Ɉ����p����܂��B

`CanvasCustomCounter`�N���X�́A��`���ꂽCanvas�I�u�W�F�N�g��T���悤�ɐ݌v����Ă���A���O�Ⓖ�ڎQ�Ƃł��邩�ǂ����ɂ�����炸�A�����Counters+�V�X�e���ɍĔz�u���܂��B

### CanvasReference
����́A`Canvas`�I�u�W�F�N�g�𒼐ڎw�肷�鉼�z�v���p�e�B�i�I�[�o�[���C�h�̓I�v�V�����j�ł��B�܂��͂�����g���Ă݂Ă��������B�o���Ă����Ă��������B���Ȃ����g�p����J�X�^���E�J�E���^�[�́AZenject �̗��_���ő���Ɋ��p���邱�Ƃ��ł��܂��B�����A���Ȃ���MOD���Ǝ��̃R���|�[�l���g��Zenject���g�p���Ă���̂ł���΁A���C����Canvas��Custom Counter�^�C�v�ɊȒP�ɒ������邱�Ƃ��ł��܂��B

### CanvasObjectName
����͉��z�v���p�e�B�ł���i�I�[�o�[���C�h�̓I�v�V�����j�ACanvas�R���|�[�l���g���A�^�b�`���ꂽGameObject�̐��m�Ȗ��O���A�啶������������ʂ��Ďw�肷��BCounters+�́A����`Canvas`�I�u�W�F�N�g�������邽�߂ɁA�J�X�^���J�E���^�[��10��̃V���b�g��^���āA���߂����܂��B

### PreReparent
Counters+��Canvas���������悤�Ƃ���O�ɋN������鉼�z���\�b�h�ł��i�I�[�o�[���C�h�͔C�Ӂj�B�����`CounterInit`�Ɗ�{�I�ɂ͓����ł����A�C�x���g�̃T�u�X�N���C�u���K�v�ȏꍇ�ɂ́A���̃��\�b�h���g�p���܂��B

### PostReparent
����́ACounters+��Canvas��Counters+�V�X�e���ɍăy�A�����O���邱�Ƃɐ���������ɋN�������o�[�`�������\�b�h�ł��i�I�[�o�[���C�h�͔C�ӂł��j�B�Ĕz�u��蓮�ł̍�Ƃ��K�v�ȏꍇ�́A`PostReparent`�֐��ōs�����Ƃ��ł��܂��B

## Helper Interfaces
------------------------------------------------------------------------------------------------------------------
�������A���ꂾ���ł͂���܂���B

Counters+�ɂ́A�m�[�g�J�b�g/�~�b�V���O��X�R�A�X�V�Ȃǂ̊�{�I�ȃQ�[���C�x���g���w�ǂ���K�v������ꍇ�A�����̃C�x���g�����J����C���^�[�t�F�C�X������A�����ŃI�u�W�F�N�g���t�@�����X��T���Ă����̃C�x���g���w�ǂ��Ȃ��Ă��A�����I�ɃC�x���g���������܂��B
����ɁA�����̃C���^�[�t�F�C�X�́A�Q�[���̃A�b�v�f�[�g��Mod����ꂽ�ꍇ�ɁACounters+��1�ӏ���������悤�ɐ݌v����Ă��܂��B�܂�A���͈�ӏ������R�[�h���C������΂悭�A�����̃C���^�[�t�F�C�X�͊��S�ɓ��삷��Ƃ������Ƃł��B

�����̃w���p�[�C���^�[�t�F�[�X�́A`CountersPlus.Counters.Interfaces` ���O��Ԃɂ���܂��B

## INoteEventHandler
���̃C���^�[�t�F�[�X�́A��{�I�ȃm�[�g�J�b�g�ƃ~�b�V���O�C�x���g�����J���܂��B

## IScoreEventHandler
���̃C���^�[�t�F�[�X�́A��{�X�R�A�X�V�C�x���g�ƍő�X�R�A�X�V�C�x���g�����J���܂��B�ǂ���̃��\�b�h���C���X�R�A�i���[�U�[�̏C���{�[�i�X���l�������X�R�A�j�݂̂�񋟂��܂��B

