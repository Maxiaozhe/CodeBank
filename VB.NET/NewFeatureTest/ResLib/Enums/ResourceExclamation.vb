Option Compare Binary
Option Explicit On
Option Strict On

Imports System

'
' �x��
'
Namespace Exclamation
#Region " Common "

    ''' <summary>
    ''' �A�v���P�[�V�������ʂ̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [Common]

        ''' <summary>
        '''{0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 3010001

        ''' <summary>
        ''' �l��������荞�ݒ��̂��߁A���� R@bitFlow �𗘗p���邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CoordinationWithPersonnel = 3010002

        ''' <summary>
        ''' ��������͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        ConditionError = 3010003

        ''' <summary>
        ''' ����{0}�͊��ɍ폜����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DeletedCondition = 3010004

        ''' <summary>
        ''' �폜�������ڂ����݂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DeletedCondition2 = 3010005
    End Enum

#End Region

#Region " RFLW "

    ''' <summary>
    ''' R@bitFlow �N���C�A���g�̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFLW]

        '''' <summary>
        ''''���[�U�[ID����͂��ĉ������B
        '''' </summary>
        '''' <remarks></remarks>
        'UserID = 3020001

        '''' <summary>
        ''''�p�X���[�h����͂��ĉ������B
        '''' </summary>
        '''' <remarks></remarks>
        'Password = 3020002

        '''' <summary>
        ''''���[�U�[ID������������܂���B
        '''' </summary>
        '''' <remarks></remarks>
        'UserIDMistake = 3020003

        '''' <summary>
        ''''�p�X���[�h������������܂���B
        '''' </summary>
        '''' <remarks></remarks>
        'PasswordMistake = 3020004

        ''' <summary>
        '''���̕����ɎQ�ƌ�������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DoumentAuthority = 3020005

        '''' <summary>
        ''''�Ǘ��҂ł̓��O�C���ł��܂���B
        '''' </summary>
        '''' <remarks></remarks>
        'LoginAdministrator = 3020006

        '''' <summary>
        ''''�L���r�l�b�g�̃p�X���[�h������������܂���B
        '''' </summary>
        '''' <remarks></remarks>
        'CabPassMistake = 3020007

        ''' <summary>
        '''���͍��ڂ����ׂē��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ChangePassword = 3020008

        ''' <summary>
        '''�V�����p�X���[�h������������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ChangeNewPassword = 3020009

        ''' <summary>
        '''�V�����p�X���[�h�͂Q�O�����ȓ��œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ChangeNewPassLen = 3020010

        ''' <summary>
        '''�V�����p�X���[�h�͑O��̃p�X���[�h�Ɠ������͎̂g���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ComparePassword = 3020011

        ''' <summary>
        '''���p�X���[�h������������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        OldPassError = 3020012

        '''' <summary>
        ''''���[�U�[�����݂��܂���B
        '''' </summary>
        '''' <remarks></remarks>
        'UserError = 3020013

        '''' <summary>
        ''''�I�����ꂽ�L���r�l�b�g�ɂ͕ۑ��ł��܂���B
        '''' </summary>
        '''' <remarks></remarks>
        'SaveCabinetError = 3020014

        ''' <summary>
        '''���݂̃p�X���[�h������������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NowPasswordError = 3020015

        ''' <summary>
        '''�o�^�ԍ������͂���Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNoNotInput = 3020016

        ''' <summary>
        '''���̌��J�҂͍폜�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        PublicationCanNotDelete = 3020017

        ''' <summary>
        '''���̎Q�Ǝ҂͍폜�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ReferenceCanNotDelete = 3020018

        ''' <summary>
        '''�w�肵���o�^�ԍ��͊��Ɏg�p����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNumberDuplicatedException = 3020019

        ''' <summary>
        '''�A�Ԃ��L�������𒴂��܂����B
        ''' </summary>
        ''' <remarks></remarks>
        NumberOutOfRangeException = 3020020

        ''' <summary>
        '''�ŏI�ۑ���E�ŏI�۔F�悪���ݒ�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        NonInputRidocDirectory = 3020021

        ''' <summary>
        '''����������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NonInputDocName = 3020022

        ''' <summary>
        '''�Ŕԍ��𐔒l�œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CreateVersionNoFailed = 3020023

        ''' <summary>
        '''�Ŕԍ��͌��݂̔ł��傫���l���w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        OverPresentVersion = 3020024

        ''' <summary>
        '''���̃t�H�[���͑㗝{0}���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotMakeDocument = 3020025

        ''' <summary>
        '''�o�^�ԍ��͈̔͂��w�肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNumberNotAppointBound = 3020026

        ''' <summary>
        '''�Ǘ��ԍ��͈̔͂��w�肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ControlNumberNotAppointBound = 3020027

        ''' <summary>
        '''�쐬���͈̔͂��w�肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MakeDateNotAppointBound = 3020028

        ''' <summary>
        '''�񓚊����͈̔͂��w�肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ResponseDateNotAppointBound = 3020029

        ''' <summary>
        '''���F���͈̔͂��w�肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        AcceptDateNotAppointBound = 3020030

        ''' <summary>
        '''�J�n�쐬���t���I���쐬���t�𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        MakeDateExcess = 3020031

        ''' <summary>
        '''�J�n�񓚊������I���񓚊����𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ResponseDateExcess = 3020032

        ''' <summary>
        '''�J�n���F���t���I�����F���t�𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        AcceptDateExcess = 3020033

        ''' <summary>
        '''�쐬���͓��t���ڂ̂��߁A�wYYYY/MM/DD�x�`���œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MakeDateNotIsDate = 3020034

        ''' <summary>
        '''�񓚊����͓��t���ڂ̂��߁A�wYYYY/MM/DD�x�`���œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ResponseDateNotIsDate = 3020035

        ''' <summary>
        '''���F���͓��t���ڂ̂��߁A�wYYYY/MM/DD�x�`���œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        AcceptDateNotIsDate = 3020036

        ''' <summary>
        '''�쐬���̓��͉\�͈͂𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        MakeDateOutOfBound = 3020037

        ''' <summary>
        '''���F���̓��͉\�͈͂𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        AcceptDateOutOfBound = 3020038

        ''' <summary>
        '''���Ԃ͓��t���ڂ̂��߁A�wYYYY/MM/DD�x�`���œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ProxyDateNotIsDate = 3020039

        ''' <summary>
        '''�J�n���t���I�����t�𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ProxyDateExcess = 3020040

        ''' <summary>
        '''�J�n������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ProxyDunInputStartDate = 3020041

        ''' <summary>
        '''���͉\�͈͂𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ProxyDateOutOfBound = 3020042

        ''' <summary>
        '''�R�����g����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CommentDunInput = 3020043

        ''' <summary>
        '''�񓚊�������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ReplayTermDunInput = 3020044

        ''' <summary>
        '''�񓚊����͓��t���ڂ̂��߁A�wYYYY/MM/DD�x�`���œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ReplayTermNotIsDate = 3020045

        ''' <summary>
        '''���͉\�͈͂𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ReplayTermOutOfBound = 3020046

        ''' <summary>
        '''�㗝�҂̗L�����Ԃ��㗝�ғ��l�̏������Ԃ𒴂��Ă��邽�ߓo�^�ł��܂���B{0}���Ԃ��ē��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ProxyOverRangeBelong = 3020047

        ''' <summary>
        '''�I�����ꂽ����������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        AcceptNoData = 3020048

        ''' <summary>
        '''���̕����͉����ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotRevision = 3020049

        ''' <summary>
        '''���̃t�@�C���̓T�|�[�g����Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        RidocNoSupportFormat = 3020050

        ''' <summary>
        '''���łɑI������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        SameFileSaved = 3020051

        ''' <summary>
        '''�I�����ꂽ�����͂��łɑI������Ă��܂��B�ʂ̕�����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RidocFileSelected = 3020052

        ''' <summary>
        '''0�o�C�g�̃t�@�C���͓Y�t�ł��܂���B�ʂ̃t�@�C����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        FileLengthCheck = 3020053

        ''' <summary>
        '''�Y�t�t�@�C���̃T�C�Y���傫�����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        FileLengthCheck_sizeOver = 3020054

        ''' <summary>
        '''99�t�@�C���𒴂��ēY�t�ł��܂���
        ''' </summary>
        ''' <remarks></remarks>
        FileLengthCheck_tenpuSuuOver = 3020055

        ''' <summary>
        '''�t�@�C�����ɖ����ȕ������܂܂�Ă��܂��B{0}  ���� %
        ''' </summary>
        ''' <remarks></remarks>
        FileNameCheck = 3020056

        ''' <summary>
        '''�t�@�C�����ɖ����ȕ������܂܂�Ă��܂��B{0}  ���� ����
        ''' </summary>
        ''' <remarks></remarks>
        FileNameCheck2 = 3020057

        ''' <summary>
        '''�t�@�C�����ɖ����ȕ������܂܂�Ă��܂��B{0}  ���� ,
        ''' </summary>
        ''' <remarks></remarks>
        FileNameCheck3 = 3020058

        ''' <summary>
        '''�t�@�C�����ɖ����ȕ������܂܂�Ă��܂��B{0}  ���� '
        ''' </summary>
        ''' <remarks></remarks>
        FileNameCheck4 = 3020059

        ''' <summary>
        '''�t�@�C�����ɖ����ȕ������܂܂�Ă��܂��B{0}  ���� #
        ''' </summary>
        ''' <remarks></remarks>
        FileNameCheck5 = 3020060

        ''' <summary>
        '''���J�҂ɐݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetPublic = 3020061

        ''' <summary>
        '''�ҏW�҂ɐݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetEdit = 3020062

        ''' <summary>
        '''�Q�Ǝ҂ɐݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetRefer = 3020063

        ''' <summary>
        '''�m�F�҂ɐݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetChecker = 3020064

        ''' <summary>
        '''���[�����M�҂ɐݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetMailUser = 3020065

        ''' <summary>
        '''���[�g�ɐݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetAccepter = 3020066

        ''' <summary>
        '''�m�F�҂�ݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CheckerNotSetup = 3020067

        ''' <summary>
        '''�\���҂͂P�l�ȏ�w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ClamorChkMin = 3020068

        ''' <summary>
        '''�\���҂͂P�O�l�ȏ�w��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ClamorChkMax = 3020069

        ''' <summary>
        '''����̐\���҂��w�肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ClamorChkRepeat = 3020070

        ''' <summary>
        '''�^�C�g���I���A�^�C�g�����͂������Ƃ��ݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ClamorChkTitle = 3020071

        ''' <summary>
        '''�{�̋��z�ɕs���ȕ��������͂���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ClamorChkKingaku = 3020072

        ''' <summary>
        '''�ŋ��ɕs���ȕ��������͂���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ClamorChkZeikin = 3020073

        ''' <summary>
        '''�N�ɕs���Ȓl�����͂���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        MakeNumYearCHKErr = 3020074

        ''' <summary>
        '''�N�͗��N���傫���N�͐ݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MakeNumYearOverErr = 3020075

        ''' <summary>
        '''�N�͋��N��菬�����N�͐ݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MakeNumYearUnderErr = 3020076

        ''' <summary>
        '''�N�ɒl�����͂���Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MakeNumYearNoInput = 3020077

        ''' <summary>
        '''���z���o�^�ł���l�𒴂��Ă��܂��B�o�^�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        InputMoneyOverErr = 3020078

        ''' <summary>
        '''���z���o�^�ł���l��������Ă��܂��B�o�^�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        InputMoneyUnderErr = 3020079

        ''' <summary>
        '''�^�C�g�����z�ɕs���Ȓl�����͂���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        NumericMoneyErr = 3020080

        ''' <summary>
        '''�\�Z���ߋ��z�ɕs���Ȓl�����͂���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        NumericOverMoneyErr = 3020081

        ''' <summary>
        '''���ɕʃ��[�U�[���J���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ExclusiveChk = 3020082

        ''' <summary>
        '''���͂��ꂽ�����L�[�ł͊Y�������������\��������܂��B�ēx�A�����L�[��ݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        IgnoreWord = 3020083

        ''' <summary>
        '''�\���ł���r���[������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetViewInfo = 3020084

        ''' <summary>
        '''�����A�g�D���Ғ��ł��B���΂炭�o������A�ēx���s���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3020085

        ''' <summary>
        '''�I�����ꂽ�����́A���ɍ폜����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ExiStenceDocChk = 3020086

        ''' <summary>
        '''�����̐V�K�쐬�̌���������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MakeNewDoc = 3020087

        ''' <summary>
        '''���̕����́A���ɐR���E���F������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        NotActionDoc = 3020088

        ''' <summary>
        '''�I������Ă���\���҂��A���[�g��ɑ��݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        RequestChkNoRouteErr = 3020089

        ''' <summary>
        '''�I������Ă���\���҂��A���[�g��̍ŏI�҂ɂȂ��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        RequestChkEndRouteErr = 3020090

        ''' <summary>
        '''�I������Ă���\���҂��A�\���҂Ƃ��ď����𖞂����Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        RequestChkLvPowerErr = 3020091

        ''' <summary>
        '''���̃��[�g�͎g�p�ł��܂���B{0}�V�K�쐬�{�^���Ń��[�g��ݒ肷�邩�A�Ǘ��҃c�[���ōĒ�`����K�v������܂��B
        ''' </summary>
        ''' <remarks></remarks>
        RouteMenberNoData = 3020092

        ''' <summary>
        '''���̃��[�g�͎g�p�ł��܂���B{0}�V�K�쐬�{�^���Ń��[�g��ݒ肷�邩�A�Ǘ��҃c�[���ōĒ�`����K�v������܂��B
        ''' </summary>
        ''' <remarks></remarks>
        RouteGroupNoData = 3020093

        ''' <summary>
        '''�I�����ꂽ���[�g�́A����������g�p���Ă��邽�߁A�ҏW�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        RouteTermsPointChk = 3020094

        ''' <summary>
        '''�L�����ɒB���Ă��Ȃ����߁A�������s�����Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DireCtorDayChk = 3020095

        ''' <summary>
        '''�g�p���Ă���t�H�[���̃��[�g�ݒ肪�ύX����Ă��܂��B�ēx�A���[�g�ύX���s���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        UnionRouteChk = 3020096

        ''' <summary>
        '''���݁A�ݒ肳��Ă��郋�[�g�͕ʂ̒S���҂Őݒ肳��Ă��܂�{0}�ēx�A���[�g�ύX�{�^���Ń��[�g���Đݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ChkDocUser = 3020097

        ''' <summary>
        '''���ځu{0}�v�͕K�{���ڂł��B�l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        GUIMustInputCHKErr = 3020098

        ''' <summary>
        '''�R������F����������艺��邽�߁A�폜�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ChkNoPersons = 3020099

        ''' <summary>
        '''���[�����M�҂�I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ChkMailUser = 3020100

        ''' <summary>
        '''���̕����́A���ɑ��̃��[�U�[�ɂ��X�V����Ă��܂��B{0}�������ēx�A�J�������ĉ������B{0}���F�ҏW���ꂽ���ڂɂ��ẮA���������̓��[�h�p�b�g�ɕۑ����A{0}�ēx�A�������č쐬���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ChkDocItemValue = 3020101

        ''' <summary>
        '''���̕����́A�ԐM�������ݒ肳��Ă��邽�߁A�폜�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ChkDocDelete = 3020102

        ''' <summary>
        '''���X�t�H�[���̍��ڂ�\������r���[�������Ŏg�p���邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotUseResFormView = 3020103

        ''' <summary>
        '''����̏����҂ł̕��s�R���ݒ�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotRouteSameLevelChk = 3020104

        ''' <summary>
        '''�ݔ��\�����̊����C���E���߂��ł��B{0}�Г��g�b�v�y�[�W�́u�ݔ��\���쐬�v�ŊY���\����I�����A[���F�t���[��]�{�^���������ĉ������B{0}���̌�A���̉�ʂ�菳�F�t���[���ĊJ���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotCutIntoOn = 3020105

        ''' <summary>
        '''�g�D�͑I���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectOrg = 3020106

        ''' <summary>
        '''�O���[�v�͑I���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectGrp = 3020107

        ''' <summary>
        '''���̃A�J�E���g�͌��݃��b�N����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        AccountLockMessage = 3020108

        ''' <summary>
        '''���͂��ꂽ�p�X���[�h�͍ŏ������񒷂𖞂����Ă��܂���B{1}{0}�����ȏ�ɐݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MinPasswordMessage = 3020109

        ''' <summary>
        '''���͂��ꂽ�p�X���[�h�͍ő啶���񒷂𒴂��Ă��܂��B{1}{0}�����ȓ��ɐݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MaxPasswordMessage = 3020110

        ''' <summary>
        '''���͂��ꂽ�p�X���[�h�ɐ��l���܂܂�Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NumberPasswordMessage = 3020111

        ''' <summary>
        '''���͂��ꂽ�p�X���[�h�ɋL�����܂܂�Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MarkPasswordMessage = 3020112

        ''' <summary>
        '''���͂��ꂽ�p�X���[�h�ɑ啶�������������݂���Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CapsPasswordMessage = 3020113

        ''' <summary>
        '''���͂��ꂽ�p�X���[�h�ɗ��p�҂h�c���܂܂�Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        UserIdPasswordMessage = 3020114

        ''' <summary>
        '''���͂��ꂽ�p�X���[�h�ɓ��ꕶ�����J��Ԃ���Ă��܂��B{1}{0}�����ȏ�̌J��Ԃ����Ȃ��ݒ�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RepeatStringPasswordMessage = 3020115

        ''' <summary>
        '''���͂��ꂽ�p�X���[�h�ɋ֑��������܂܂�Ă��܂��B{1}�u{0}�v�̓p�X���[�h�ɐݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        WrapPasswordMessage = 3020116

        ''' <summary>
        '''���͂��ꂽ�p�X���[�h�͉ߋ��Ɏg��ꂽ�p�X���[�h�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        HistoryPasswordMessage = 3020117

        ''' <summary>
        '''�A�g���ڂ̍X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DataTransferAbortMessage = 3020118

        ''' <summary>
        '''�ۑ��\�ȃt�@�C���̃T�C�Y�𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        OverSizeMessage = 3020119

        ''' <summary>
        '''�I�������t�@�C���̓T�|�[�g����Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FileNoSupportMessage = 3020120

        ''' <summary>
        '''�ꊇ������s���������I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        PrintFileNoSelectMessage = 3020121

        ''' <summary>
        ''' ����{0}���J���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        UserOpenedMessage = 3020122

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        OtherMessage = 3020123

        ''' <summary>
        ''' �㗝�҂Ƃ��Ď������w�肷�邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        SystemOwnChk = 3020124

        ''' <summary>
        ''' ����̑㗝�҂ő㗝�������w�肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DaiSameChk = 3020125

        ''' <summary>
        ''' ���ځu{0}�v�̓��͒l�́u922,337,203,685,477.5807�v����u-922,337,203,685,477.5808�v�͈̔͂ɂ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        DecimalOverFlow = 3020126

        ''' <summary>
        ''' ���ځu{0}�v�̓��͒l�́u2,147,483,647�v����u-2,147,483,648�v�͈̔͂ɂ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        Int32OverFlow = 3020127

        ''' <summary>
        ''' ���[�g���w�肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotSettingRoute = 3020128

        ''' <summary>
        ''' ��̏��F�K�w�ɓ����l�͒ǉ��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectSamePerson = 3020129

        ''' <summary>
        ''' �{�l�͐ݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectSelfUser = 3020130

        ''' <summary>
        ''' ���[�UID�܂��̓p�X���[�h���Ԉ���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        LoginFailed = 3020131

        ''' <summary>
        ''' �㗝�҂ɂ�鏈���͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotProcessByDuplicator = 3020132

        ''' <summary>
        ''' �����ł��Ȃ��������܂܂�Ă��܂��B�r���[��ʂ��當����I���������Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotProcessInDocument = 3020133

        ''' <summary>
        ''' ���[�U�h�c�܂��̓��[���A�h���X���Ԉ���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        NonUserMessage = 3020134

        ''' <summary>
        '''�I�����ꂽ�t�H�[�������݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FormNotExisted = 3020135

        ''' <summary>
        ''' ���񃍃O�C���ł��B�p�X���[�h��ύX���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        InitPasswordMessage = 3020136

        ''' <summary>
        ''' �p�X���[�h�̗L���������؂�܂����B�p�X���[�h��ύX���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        ChangePasswodMessage = 3020137

        ''' <summary>
        ''' �����{��������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        RGUINoDocumentReadAccess = 3020138
        ''' <summary>
        ''' �t�H�[���𗘗p�ł��Ȃ����[�U�[�܂��͑g�D/�O���[�v�͒ǉ��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectUserForRoute = 3020139

        ''' <summary>
        ''' �F�؂Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ErrorInLogin = 3020140

        ''' <summary>
        ''' �w�肳�ꂽ���F�҂͐ݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectRouteChange = 3020141

        ''' <summary>
        ''' �������Ȃ����߃��[�g�Ɏw�肷�邱�Ƃ͏o���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoRightOfAccess = 3020142

    End Enum

#End Region

#Region " NGUI "

    ''' <summary>
    ''' NGUI �v���W�F�N�g�̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [NGUI]

        ''' <summary>
        '''���ځu{0}�v�̐݌v��񂪕s���S�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        FieldParamIncompleteExclamationMessage = 3030001

        ''' <summary>
        '''���ځu{0}�v�͕K�{���ڂł��B�l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MustInputUnsatedExceptionExclamationMessage = 3030002

        ''' <summary>
        '''���ځu{0}�v�̓��͒l�́u922,337,203,685,477.5807�v����u-922,337,203,685,477.5808�v�͈̔͂ɂ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MonneyOverFlow = 3030003

        ''' <summary>
        '''���ځu{0}�v�̓��͒l�́u2,147,483,647�v����u-2,147,483,648�v�͈̔͂ɂ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        IntOverFlow = 3030004

        ''' <summary>
        '''���ځu{0}�v�͕s���ȓ��t�ł��B���������t����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ChangeGregorianExFailed = 3030005

        ''' <summary>
        '''�Y�t�t�@�C�����w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotAddFileExceptionExclamationMessage = 3030006

        ''' <summary>
        '''���݂̔ł��傫���l�𐔒l�œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        OverPresenteVersion = 3030007

        ''' <summary>
        '''�ŏI�ۑ���E�ŏI�۔F����w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotCabSelectedExceptionExclamationMessage = 3030008

        ''' <summary>
        '''99.99�𒴂��Ĕł��X�V���邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotRevisionMessage = 3030009

        ''' <summary>
        '''�t�H�[���̐ݒ��񂪕s�\���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        NoSetRidocEntryMessage = 3030010

        ''' <summary>
        '''�����Y�t�s�̃t�@�C�����܂܂�Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        UnjustAttachedFileMessage = 3030011

        ''' <summary>
        '''�Ŕԍ��͕K�{���ڂł��B�l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotInputVersionMessage = 3030012

        ''' <summary>
        '''���ځu{0}�v�̓��͒l�́u1753�N1��1���v����u9999�N12��31���v�͈̔͂œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        InputDateOutOfRange = 3030013

        ''' <summary>
        '''�����A�g�D���Ғ��ł��B���΂炭�o������A�ēx���s���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3030014

        ''' <summary>
        '''�J�n���A�I���������ꂩ�������͂ł̓o�^�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        AnotherNonInputItem = 3030015

        ''' <summary>
        '''�J�n���͏I�����ȑO�̓��t����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ChangeDateItem = 3030016

        ''' <summary>
        '''�J�n������I�����͈̔͂�{0}���Ԉȓ��ɂ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RangeOverDateItemDay = 3030017

        ''' <summary>
        '''�J�n������I�����͈̔͂�{0}�����Ԉȓ��ɂ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RangeOverDateItemMonth = 3030018

        ''' <summary>
        '''�J�n������I�����͈̔͂�{0}�N�Ԉȓ��ɂ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RangeOverDateItemYear = 3030019

        ''' <summary>
        '''�J�n������I�����͈̔͂�{0}�N�ȓ��ɂ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RangeOverDateItemOneYear = 3030020

        ''' <summary>
        '''���ځu�����v�͕K�{���ڂł��B�l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NameMustInput = 3030021

        ''' <summary>
        '''���ځu�e�`�w�ԍ��v�͕K�{���ڂł��B�l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        FaxMustInput = 3030022

        ''' <summary>
        '''���ځu{0}�v�͕s���Ȏ��Ԃł��B���������Ԃ���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        TimeInputError = 3030023

        ''' <summary>
        '''���[���C�A�E�g�����݂��Ȃ��������܂܂�Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        NotLayoutFileInDocument = 3030024

        ''' <summary>
        ''' ����ł���f�[�^�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonPrintDataMessage = 3030025

        ''' <summary>
        '''���ځu{0}�v�͕s���Ȑ��l�ł��B���������l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NumericErrorMessage = 3030026

        ''' <summary>
        '''�I�����ꂽ�����͒��[���C�A�E�g��������܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        NoReportLayout = 3030027

    End Enum

#End Region

#Region " VEGG "

    ''' <summary>
    ''' VEGG �v���W�F�N�g�̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VEGG]

        ''' <summary>
        ''' �J�e�S���͑I���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MustNotCategorySelected = 3040001

        ''' <summary>
        ''' �ǉ����郋�[�g��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        AddRouteUnSelected = 3040002

        ''' <summary>
        ''' �폜���郋�[�g��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RemoveRouteUnSelected = 3040003

        ''' <summary>
        ''' ���łɓ������[�g���I������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        SameRouteExist = 3040004

        ''' <summary>
        ''' �ǉ�����t�H�[����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        AddFormUnSelected = 3040005

        ''' <summary>
        ''' �폜����t�H�[����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RemoveFormUnSelected = 3040006

        ''' <summary>
        ''' ���łɓ����t�H�[�����I������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        SameFormExist = 3040007

        ''' <summary>
        ''' �r���[�̖����w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        SetNoViewName = 3040008

        ''' <summary>
        ''' �o�͂��鍀�ڂ��w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        SetNoViewColumn = 3040009

        ''' <summary>
        ''' ���l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        UnNumeric = 3040010

        ''' <summary>
        ''' �̔Ԃ��s���ۂ̗L��������1�`10���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        VlDocNoFigOver10 = 3040011

        ''' <summary>
        ''' �̔ԍ��ڂɎw��\�ȍ��ڂ�20���ڂ܂łł��B
        ''' </summary>
        ''' <remarks></remarks>
        DocColStructOver20 = 3040012

        ''' <summary>
        ''' �̔ԍ��ڂɘA�Ԃ�o�^���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        DocColStructNoCounter = 3040013

        ''' <summary>
        ''' �̔ԍ��ڂ̍폜�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DocColStructCounterNotDelete = 3040014

        ''' <summary>
        ''' ���F���ۑ���͕K�{���͂ł��B{0}�ۑ�����w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        SetFullPassLblNmPubDoc = 3040015

        ''' <summary>
        ''' �۔F���ۑ���͕K�{���͂ł��B{0}�ۑ�����w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        SetFullPassLblNmNyDoc = 3040016

        ''' <summary>
        ''' �J�e�S��������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        UnInputCategoryName = 3040017

        ''' <summary>
        ''' �\����������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        UnInputCategoryDispNo = 3040018

        ''' <summary>
        ''' �J�e�S����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CategoryUnSelcted = 3040019

        ''' <summary>
        ''' ���͉\�Ȕ͈͂𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        OverRange = 3040020

        ''' <summary>
        ''' ���݂��̃t�H�[���͎g�p���ł��B�폜�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FormExecutingNotDelte = 3040021


        ''' <summary>
        ''' �t�H�[���̖�����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        UnInputFormName = 3040022

        ''' <summary>
        ''' ���̃��[�g�͏��������ێ����܂��B{0}���̃t�H�[���ƕ��p������A�g�p�t�H�[����ύX���邱�Ƃ͏o���܂���B
        ''' {0}�g�p�t�H�[���̕ύX������ꍇ�́w���[�g�C���x�{�^�����N���b�N���A{0}���̃��[�g����������̖�����Ԃɂ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RuteHasBranch = 3040023

        ''' <summary>
        ''' �I�����ꂽ���[�g�͏�������ɑ��̃t�H�[���̍��ڂ��w�肳��Ă��܂��B{0}���̃t�H�[���Ŏg�p���邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        SelectedRuteHasBranch = 3040024

        ''' <summary>
        ''' �I�����ꂽ���[�g�͏�������ɂ��̃t�H�[���̍��ڂ��w�肳��Ă��܂��B{0}�폜���邱�Ƃ͂ł��܂���B
        ''' {0}�폜����ꍇ�̓��C����ʂ́w���[�g�C���x�{�^�����N���b�N���A{0}���̃��[�g����������̖�����Ԃɂ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RemoveRuteHasBranch = 3040025

        ''' <summary>
        ''' �ؗ����Ԃ̓��͂͂P�c�Ɠ��ȏ���w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        OverRengeVlttl = 3040026

        ''' <summary>
        ''' Ridoc�A�g�ŕ����v���p�e�B�ݒ�̓o�^���s���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        DocNotAddPropatyChk = 3040027

        ''' <summary>
        ''' �t�H�[�������J���ׁ̈A�폜�ł��܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedNotDelete = 3040028

        ''' <summary>
        ''' ���ɑI������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DupSelect = 3040029

        ''' <summary>
        ''' ���X�t�H�[���͊��ɓo�^����Ă��܂��B{0}�V�K�쐬����ꍇ�́A�����̃��X�t�H�[�����폜���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ResOnlyOne = 3040030

        ''' <summary>
        ''' �g�p�Ώۂf�t�h���ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoGuiSelect = 3040031

        ''' <summary>
        ''' ���X�K�w�ɂ͐��l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ResUnNumeric = 3040032


        ''' <summary>
        ''' �I���������ڂŌ�������ɂ͂��ׂẴr���[���ēo�^����K�v������܂��B{0}�r���[��I�����ēo�^�{�^�����N���b�N���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ReSetupView = 3040033


        ''' <summary>
        ''' �œK�������s���邱�Ƃ��ł��܂���B{0}�I�����ڂ��m�F���Ă���ēx���s���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotExecuteOptimize = 3040034

        ''' <summary>
        ''' ���ɖ߂����Ƃ��ł��܂���B{0}�I�����ڂ��m�F���Ă���ēx���s���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotExecuteUndo = 3040035

        ''' <summary>
        ''' �I�����ꂽ�L���r�l�b�g�̃p�X���[�h��ݒ��ʂœo�^���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CabPassNotRegistration = 3040036

        ''' <summary>
        ''' �ۑ�����w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CabinetNotSelected = 3040037

        ''' <summary>
        ''' �C�ӕ�����͔��p�p���œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        UnjustTxtFree = 3040038

        ''' <summary>
        ''' �A�g����v���p�e�B��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        DocPropNotSelected = 3040039

        ''' <summary>
        ''' �����ݑΏۃv���p�e�B���d�����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DocPropDuplication = 3040040


        ''' <summary>
        ''' Ridoc�v���p�e�B�u�������v�ւ́u�����ݐݒ�v�͕K�{�ł��B{0}�t�H�[���ɓ\�t���Ă��鍀�ڂ��ARidoc�v���p�e�B�u�������v�Ɂu�����ݐݒ�v���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        DocNamePropNonSet = 3040041

        ''' <summary>
        ''' �I�����ꂽ�����v���p�e�B�͗\��v���p�e�B���ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DocPropNonSet = 3040042


        ''' <summary>
        ''' �����Ǘ��c�[���ɂĕ����^�C�v�̓o�^���s���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        DocTypeNonSet = 3040043

        ''' <summary>
        ''' ����ݒ�ʒu���d�����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        PrintDataDuplication = 3040044

        ''' <summary>
        ''' �񓚊�������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ReplyLimit = 3040045

        ''' <summary>
        ''' �񓚊����̓��͂�1�c�Ɠ��ȏ���w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ReplyLimitOutOfRange = 3040046


        ''' <summary>
        ''' ������񂪏d�����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DupAuthInfo = 3040047

        ''' <summary>
        ''' �R�s�[��񂪏d�����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DupCopyInfo = 3040048

        ''' <summary>
        ''' �R�s�[��񂪂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoCopyinfo = 3040049


        ''' <summary>
        ''' �I�����ꂽ�����f�[�^���폜���錠��������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        AssignNoAuth = 3040050

        ''' <summary>
        ''' �����A�g�D���Ғ��ł��B���΂炭�o������A�ēx���s���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3040051

        ''' <summary>
        ''' ������I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectedDocumentList = 3040052

        ''' <summary>
        ''' {0}�����̂ݑI���\�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectedDraftOnly = 3040053


        ''' <summary>
        ''' ���[�N�t���[�܂��͌��J�f���̂ݑI���\�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectedRouteForm = 3040054

        ''' <summary>
        ''' ��t���������̂ݑI���\�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectedReferData = 3040055

        ''' <summary>
        ''' ��t�����S����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectedAddReferData = 3040056

        ''' <summary>
        ''' �P�����̂ݑI���\�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectedOneOnly = 3040057

        ''' <summary>
        ''' �J�n�ƏI���͈Ⴄ���Ԃœo�^���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        TimeAbonMessage = 3040058

        ''' <summary>
        ''' �t�H�[������폜���ꂽ���ڂ��r���[�Ŏg�p����Ă��܂��B{0}�r���[�G�f�B�^�ŏC�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CheckViewSQLErrorMessage = 3040059

        ''' <summary>
        ''' �l���o�^��{0}���s���Ă��Ȃ����߁A�J�e�S����o�^���邱�Ƃ͂ł��܂���B{1}�J�e�S����o�^����ɂ́A�l���o�^���j���[���{0}���s���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotSettingBranch = 3040060

        ''' <summary>
        ''' �������I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNoSelected = 3040061

        ''' <summary>
        ''' ���͂��ꂽ�o�^�ԍ��͊��ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNumberDuplicate = 3040062

        ''' <summary>
        ''' �����������I������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentManySelected = 3040063
        ''' <summary>
        ''' ����������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentManagementNoAuth = 3040064


        ''' <summary>
        ''' �݌v�҂ɂ͂��ׂĂ̕������Q�Ƃ��錠���͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentManagementNoAuthAllDocument = 3040065


        ''' <summary>
        ''' �o�͂��镶��������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNoOutput = 3040066

        ''' <summary>
        ''' �o�^�ԍ��͈̔͂��w�肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNumberNotAppointBound = 3040067

        ''' <summary>
        ''' �Ǘ��ԍ��͈̔͂��w�肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ControlNumberNotAppointBound = 3040068

        ''' <summary>
        ''' �쐬���͈̔͂��w�肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MakeDateNotAppointBound = 3040069

        ''' <summary>
        ''' �񓚊����͈̔͂��w�肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ResponseDateNotAppointBound = 3040070

        ''' <summary>
        ''' ���F���͈̔͂��w�肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        AcceptDateNotAppointBound = 3040071

        ''' <summary>
        ''' �J�n�쐬���t���I���쐬���t�𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        MakeDateExcess = 3040072

        ''' <summary>
        ''' �J�n���F���t���I�����F���t�𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        AcceptDateExcess = 3040073

        ''' <summary>
        ''' �̔ԗL����������͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        DocUnNumeric = 3040074

        ''' <summary>
        ''' ���l�̌������I�[�o�[���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        OverFlowNumeric = 3040075


        ''' <summary>
        '''SQL�̐����Ɏ��s���܂����B{0}�i{1}�j
        ''' </summary>
        ''' <remarks></remarks>
        NotCreateSql = 3040076

        ''' <summary>
        '''���������SQL��������ɓ��삵�܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        NotExcuteSql = 3040077

        ''' <summary>
        '''�ꗗ�o�͍��ڂ̃\�[�g���Ԃ��w�肳��Ă��܂���B{1}[ {0} ]
        ''' </summary>
        ''' <remarks></remarks>
        SetNoSort = 3040078

        ''' <summary>
        '''�ꗗ�o�͍��ڂ� {0} ���d�����Ă��܂��B{1}�d�����Ă��鍀�ږ���ݒ肷�邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DupViewField = 3040079

        ''' <summary>
        '''�ꗗ�o�͍��ڂ̓��ꌋ�����ڂ̕\�����̂��قȂ��Ă��܂��B{2}[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        DifViewFieldName = 3040080

        ''' <summary>
        '''�O���[�v�o�͍��ڂ� {0} ���d�����Ă��܂��B{1}�d�����Ă��鍀�ږ���ݒ肷�邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DupGroupField = 3040081

        ''' <summary>
        '''�O���[�v�o�͍��ڂ̓��ꌋ�����ڂ̕\�����̂��قȂ��Ă��܂��B{2}[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        DifGroupFildName = 3040082

        ''' <summary>
        '''�ꗗ�E�O���[�v�o�͍��ڂ� {0} ���d�����Ă��܂��B{1}�d�����Ă��鍀�ږ���ݒ肷�邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DupViewGroupField = 3040083

        ''' <summary>
        '''�������ڂƂ��Ă̐ݒ�Ɍ�肪����܂��B{2}[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        NotSetUnion = 3040084

        ''' <summary>
        '''�������ڂƂ��Ďw�肵���ꍇ�ɂ́A�v�Z�w��͖����ł��B{2}[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        InvalidCalculation = 3040085

        ''' <summary>
        '''�������ڃ`�F�b�N���ɃG���[�����o���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        NotChkUnion = 3040086

        ''' <summary>
        '''���͂��ꂽ�����J�n�ʒu������������܂���B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkDivStartPosError = 3040087

        ''' <summary>
        '''���͂��ꂽ����������������������܂���B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkDivSizeError = 3040088

        ''' <summary>
        '''���͂��ꂽ��������������܂���B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkWidthError = 3040089

        ''' <summary>
        '''�\�����ڂɑΏۈȊO�̃t�H�[���̍��ڂ��I������Ă��܂��B[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkItemError = 3040090

        ''' <summary>
        '''�O���[�v�ɑΏۈȊO�̃t�H�[���̍��ڂ��I������Ă��܂��B[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkGrpItemError = 3040091

        ''' <summary>
        '''�������ڂɑΏۈȊO�̃t�H�[���̍��ڂ��I������Ă��܂��B[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkIfItemError = 3040092

        ''' <summary>
        '''�������ڂɑΏۈȊO�̃t�H�[���̍��ڂ��I������Ă��܂��B[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkUnionItemError = 3040093


        ''' <summary>
        '''RES�{�^���ݒ�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        NotSetResBtn = 3040094

        ''' <summary>
        '''�O���[�v�����ڂ��ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotSetGrp = 3040095

        ''' <summary>
        '''�O���[�v�����ڂƂ��Ďw�肳��Ă��鍀�ڂ��ő�i{0}���ځj�𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        MaxGrpFiled = 3040096

        ''' <summary>
        '''�폜�Ώۂ̃r���[�����L�����r���[�Ŏg�p����Ă���ׁA�폜�ł��܂���B{0}{1}
        ''' </summary>
        ''' <remarks></remarks>
        NotDelView = 3040097

        ''' <summary>
        '''�r���[�̃R�s�[�Ɏ��s���܂����B{0}
        ''' </summary>
        ''' <remarks></remarks>
        FailedViewCopy = 3040098

        ''' <summary>
        '''���͂��ꂽ�y�[�W���\������������������܂���B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        PageMaxChk = 3040099

        ''' <summary>
        '''���͂��ꂽ�ő�Ǎ�����������������܂���B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ReadMaxChk = 3040100

        ''' <summary>
        '''���͂��ꂽ�ő�ԐM�\���K�w������������܂���B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ResMaxChk = 3040101

        ''' <summary>
        '''�ꗗ�\�����ڂ��ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotSetView = 3040102

        ''' <summary>
        '''�t�H�[���A�����ɐݒ肳��Ă��� {0}�t�H�[���́A�ꗗ�o�͍��ڂɂ��O���[�v�����ڂɂ��ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        RelationalChk = 3040103

        ''' <summary>
        '''{0}�̃t�H�[���̂ݎw�肪�\�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        DispFormChk = 3040104

        ''' <summary>
        '''�����r���[{0}�Ŏg�p����Ă���r���[�ׁ̈A����͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ItemUserUnionErr = 3040105

        ''' <summary>
        '''[{0}({1})]�̍��ڂ������r���[{2}�Ŏg�p����Ă���ׁA�폜�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ItemUserErr = 3040106

        ''' <summary>
        '''�I�����ꂽ���ڂ��t�H�[������폜����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        SelectedFiledDel = 3040107

        ''' <summary>
        '''�I�����ꂽ���ڂ��ُ�ł��B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectedFiledErr = 3040108

        ''' <summary>
        '''40�����܂łœ��͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        MaxTxtLen40 = 3040109

        ''' <summary>
        '''G_����͂��܂鍀�ږ���ݒ肷�邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotSetGFiled = 3040110

        ''' <summary>
        '''�����J�n�ʒu���ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotSetDivPos = 3040111

        ''' <summary>
        '''�����u���b�N�����̓o�^�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        OnlyIfBloc = 3040112

        ''' <summary>
        '''�������ݒ肳��Ă��Ȃ��u���b�N�̓o�^�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotSaveIfBloc = 3040113

        ''' <summary>
        '''�L���Ȓl���I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        VaildDataNotSelected = 3040114

        ''' <summary>
        '''���͂���Ă���l��{0}�Ƃ��ĔF���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotUnderstandValue = 3040115

        ''' <summary>
        '''�w�肳�ꂽ�\���̎��́A�u{0}�v�u{1}�v�̂ݎw��\�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        RsvKindChk = 3040116

        ''' <summary>
        '''�������o�^����܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        AddDataError = 3040117

        ''' <summary>
        '''���͂��ꂽ�\�����͊��ɓo�^����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        HasNMExist = 3040118

        ''' <summary>
        '''���p50�����E�S�p25�����܂łœ��͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        MaxTxtLen50 = 3040119

        ''' <summary>
        '''�I�����ꂽ�r���[�͊��ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        HasViewExist = 3040120

        ''' <summary>
        '''�����Ώۃr���[�ꗗ���X�g�̒ǉ��Ɏ��s���܂����I
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewAddErr = 3040121

        ''' <summary>
        '''�����Ώۃr���[���ڈꗗ���X�g�̒ǉ��Ɏ��s���܂����I
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewListAddErr = 3040122

        ''' <summary>
        '''�����Ώۃr���[���ڈꗗ�i�`�k�k�j���X�g�̒ǉ��Ɏ��s���܂����I
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewAllAddErr = 3040123

        ''' <summary>
        '''�����Ώۃr���[���ڈꗗ���X�g�̏C���Ɏ��s���܂����I
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewMidifyErr = 3040124

        ''' <summary>
        '''�����Ώۃr���[�O���[�v�����ڈꗗ�i�`�k�k�j���X�g�̒ǉ��Ɏ��s���܂����I
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewGrpErr = 3040125

        ''' <summary>
        '''�\���������͂���Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NMMustInput = 3040126

        ''' <summary>
        '''�I�����ꂽ�\�����͊��ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        SelectedNMExist = 3040127

        ''' <summary>
        '''�����r���[���ڂ��I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewFieldMustSelect = 3040128

        ''' <summary>
        '''�����r���[�Ƃ��Ďw�肳�ꂽ�r���[�ō��ڂ��I������Ă��Ȃ��r���[�����݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewNotExist = 3040129

        ''' <summary>
        '''�����Ώۂ̃r���[���I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewMustSelect = 3040130

        ''' <summary>
        '''�����Ώۃr���[���ڂ̋��ʒ�`������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewItemMustDef = 3040131

        ''' <summary>
        '''�����Ώۃr���[���ڂ��I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewItemMustSelect = 3040132

        ''' <summary>
        '''�����Ώۃr���[���ڂ̐����قȂ��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewItemDif = 3040133

        ''' <summary>
        '''�����Ώۃr���[�O���[�v���ڂ̐����قȂ��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewGrpItemDIf = 3040134

        ''' <summary>
        '''�I�����ꂽ���ڂ��t�H�[������폜����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DelSelectedItem = 3040135

        ''' <summary>
        '''�\���ł���͍̂ő�{0}�{�^���܂łł��B
        ''' </summary>
        ''' <remarks></remarks>
        MaxBtnCount = 3040136

        ''' <summary>
        '''�o�^�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotAdd = 3040137

        ''' <summary>
        '''���ڈꊇ�X�V�ꗗ���X�g�̒ǉ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        NotAddItemList = 3040138

        ''' <summary>
        '''���͂��ꂽ�l�𐔒l�Ƃ��ĔF���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        InvaidNumeric = 3040139

        ''' <summary>
        '''���͂��ꂽ�l���L���͈͊O�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        InvaidValue = 3040140

        ''' <summary>
        '''���͂��ꂽ�l����t�Ƃ��ĔF���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        InvaidDate = 3040141

        ''' <summary>
        '''�I�����ꂽ���ڂ͊��ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        SelectedItemExist = 3040142

        ''' <summary>
        ''' �\���������͂���Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NameEmpty = 3040143

        ''' <summary>
        ''' �I�����ꂽ�\�����͊��ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        NameExisted = 3040144

        ''' <summary>
        ''' �l���������I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        UserListSelect = 3040145

        ''' <summary>
        ''' �O���[�v���������I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        GroupTp2SelectChk = 3040146

        ''' <summary>
        ''' {0}�̕\���������͂���Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        EmptyViewShowField = 3040147

        ''' <summary>
        ''' �������򂪑��݂��郋�[�g�����ɓo�^����Ă��܂��B{0}���̃t�H�[���Ŏg�p���邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ExistBranchRoute = 3040148
        '�w���v�ݒ�
        ''' <summary>
        ''' �����N�����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotHelpLinkUrl = 3040149
        ''' <summary>
        ''' �����N�̕\��������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotHelpLinkName = 3040150

        ''' <summary>
        ''' �r���[�����݂��邽�߉������邱�Ƃ͂ł��܂���B
        ''' ��������ɂ́A���̃��X�t�H�[���𗘗p���Ă��邷�ׂẴr���[���폜����K�v������܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ExistsResView = 3040151

        ''' <summary>
        ''' �g�D�E�O���[�v�܂��͌l��I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectReferData = 3040152

        ''' <summary>
        ''' �I�����ꂽ�g�D�E�O���[�v�͊��ɒǉ�����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        AlreadySelectedOrgReferData = 3040153

        ''' <summary>
        ''' �I�����ꂽ�l�͊��ɒǉ�����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        AlreadySelectedSelfReferData = 3040154

        ''' <summary>
        ''' �u{0}�v�́u{1}�v�͊��Ɉ��p�����ڂɐݒ�ς݂ł��B
        ''' </summary>
        ''' <remarks></remarks>
        AddedAcceptanceField = 3040155

        ''' <summary>
        ''' ���p�����ڂɃt�H�[������폜���ꂽ���ڂ��܂܂�Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        IncludeRemovedMapping = 3040156

    End Enum

#End Region

#Region " VFRM "

    ''' <summary>
    ''' VFRM �v���W�F�N�g�̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFRM]
        ''' <summary>
        '''�t�H�[��������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotFormName = 3050001

        ''' <summary>
        '''���ڕ\��������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotFieldName = 3050002

        ''' <summary>
        '''������������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotMaxLength = 3050003

        ''' <summary>
        '''���������̓��͂Ɍ�肪����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        MaxLengthError = 3050004

        ''' <summary>
        '''Ridoc�Y�t��ǉ����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotRidoc = 3050005

        ''' <summary>
        '''����l�̓��͂Ɍ�肪����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DefaultValueError = 3050006

        ''' <summary>
        '''�u{0}�v�����͉\�͈͂𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        OutofRange = 3050007

        ''' <summary>
        '''�Z���̌������ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FailedMerge = 3050008

        ''' <summary>
        '''���ڕ��̐ݒ�Ɍ�肪����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        WidthEntryError = 3050009

        ''' <summary>
        '''���ڍ����̐ݒ�Ɍ�肪����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        HeightEntryError = 3050010

        ''' <summary>
        '''�������ڐݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ListitemError = 3050011

        ''' <summary>
        '''�ꍀ��30�����ȓ��œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        LengthOverflow = 3050012

        ''' <summary>
        '''���ځu{0}�v�̃v���p�e�B��ݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotProperty = 3050013

        ''' <summary>
        '''���ځu{0}�v�̃��X�g���ڂ�ݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotListItems = 3050014

        ''' <summary>
        '''���X�g���ڂ�ݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotListItems2 = 3050015

        ''' <summary>
        '''���ځu{0}�v�����łɑ��݂��Ă���ׁA�ǉ����s�������ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        OnlyOneInsert = 3050016

        ''' <summary>
        '''�t�H�[���Ɉ�����쐬�ł��Ȃ��R���g���[��������܂��B
        ''' </summary>
        ''' <remarks></remarks>
        OnlyOneCopy = 3050017

        ''' <summary>
        '''���ځu{0}�v�͕����z�u���邱�Ƃ��ł��܂���B�폜���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        IllegalCopy = 3050018

        ''' <summary>
        '''�t�H�[���Ƀ��[�N�t���[���ږ��������͏d���������ږ���t���鎖�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FieldNameRepeated = 3050019

        ''' <summary>
        '''���͉\�͈͂𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        OutofRangeNoObj = 3050020

    End Enum

#End Region

#Region " VGUI "

    ''' <summary>
    ''' VGUI �v���W�F�N�g�̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VGUI]

        ''' <summary>
        ''' ����ڂ��I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectBaseItem = 3060001

        ''' <summary>
        ''' �퐔���ڂ��I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectCoverItem = 3060002

        ''' <summary>
        ''' �Z�p�����I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectexpressionItem = 3060003

        ''' <summary>
        ''' ���ʍ��ڂ��I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectresultItem = 3060004

        ''' <summary>
        ''' �o�͍��ڂ�I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectOutput = 3060005

        ''' <summary>
        ''' �o�^�ł���v���p�e�B������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonProperty = 3060006

        ''' <summary>
        ''' �Œ�l����͂��邩�t�B�[���h��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ValueOrField = 3060007

        ''' <summary>
        ''' ��r���ڂ�I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CompareSelect = 3060008

        ''' <summary>
        ''' ��r���Z�q��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        OperatorSelect = 3060009

        ''' <summary>
        ''' ��r�ɍ��ڂ̒l���g�p����ꍇ�́A��r���鍀�ڂ�I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CompareFieldSelect = 3060010

        ''' <summary>
        ''' ��r���鍀�ڂ̑�������v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        AttributeAgreement = 3060011

        ''' <summary>
        ''' ��r���ڂ͕�����^�ł͂Ȃ��̂Ŕ�r���邱�Ƃ��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoString = 3060012

        ''' <summary>
        ''' ��r���ڂ͐��l�^�ł͂Ȃ��̂Ŕ�r���邱�Ƃ��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoNumeric = 3060013

        ''' <summary>
        ''' ��r���ڂ͓��t�^�ł͂Ȃ��̂Ŕ�r���邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoDate = 3060014

        ''' <summary>
        ''' �o�͓��e����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ContentMustInput = 3060015

        ''' <summary>
        ''' �o�͐�̍��ڂ͕����^�łȂ���΂Ȃ�܂���B
        ''' </summary>
        ''' <remarks></remarks>
        OutColumnsMustString = 3060016

        ''' <summary>
        ''' ���l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        InputNumeric = 3060017

        ''' <summary>
        ''' ���t��YYYY/MM/DD�`���œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        InputDate = 3060018

        ''' <summary>
        '''�͈͂��w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        AppointRange = 3060019

        ''' <summary>
        '''�J�n���t���I�����t�𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        OverFlow = 3060020

        ''' <summary>
        '''�����A�g�D���Ғ��ł��B���΂炭�o������A�ēx���s���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3060021

        ''' <summary>
        '''�K�{�ݒ�Ώۂ̃R���g���[�����I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectMustInputControl = 3060022

        ''' <summary>
        '''�����ݒ�Ώۂ̃R���g���[�����I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectConditionControl = 3060023

        ''' <summary>
        '''�K�{�ݒ�ΏۂƏ����ݒ�Ώۂ̃R���g���[���𓯂��ɂ��邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetSameControl = 3060024

        ''' <summary>
        '''�����̔��f�l�����͂���Ă��܂���B�u�l���Ȃ��Ƃ��v�Ƃ��������̏ꍇ�́u""""�v�Ɠ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NonInputConditionalText = 3060025

        ''' <summary>
        '''���ɓ���̑g�ݍ��킹�����݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        NonSameCombination = 3060026

        ''' <summary>
        '''�w�肳�ꂽ���ڂɁA�����̍��ڂ̒l��ݒ肷�邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotCombinableFormField = 3060027

        ''' <summary>
        '''�Q�ƃt�H�[���E�r���[���I������Ă��Ȃ����A�t�H�[���E�r���[���폜����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectReferenceForm = 3060028

        ''' <summary>
        '''���ڋ�ؕ����ƍs��ؕ����𓯂��ɂ��邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectSameSeparator = 3060029

        ''' <summary>
        '''�w��\�ȓ��e���I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectReservItem = 3060030

        ''' <summary>
        '''�J�n������I�����܂ł͈̔͂����Ԃ̍ő�͈͂𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        OverMaxRangeItem = 3060031

        ''' <summary>
        '''0�ȏ�̐��l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MinErr1 = 3060032

        ''' <summary>
        '''1�ȏ�̐��l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MinErr2 = 3060033

        ''' <summary>
        '''�����l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MinErr3 = 3060034

        ''' <summary>
        '''�ꊇ�X�V���ڐݒ肪����܂���B
        ''' </summary>
        ''' <remarks></remarks>
        LumpItemNothing = 3060035

        ''' <summary>
        '''�w�肳�ꂽ�J������������܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgClumNotFind = 3060036

        ''' <summary>
        '''�w�肳�ꂽ�J�����Ƒ������Ⴂ�܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgClumTypeErr = 3060037

        ''' <summary>
        '''�����I�[�o�[�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgClumTypeOver = 3060038

        ''' <summary>
        '''�\�����Ȃ��G���[���������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgAbnomal = 3060039

        ''' <summary>
        '''���͉\�������𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        OverInputCharcterLength = 3060040

        ''' <summary>
        '''�Y�t�����^�C�g������ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        InputCharcterForAddFile = 3060041

        ''' <summary>
        '''�t�@�C����Y�t���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MustInputInlineGUI = 3060042

        ''' <summary>
        '''�T�u�t�H�[�����I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectSubForm = 3060043

        ''' <summary>
        '''{0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 3060044

        ''' <summary>
        '''����̃t�B�[���h���w�肷�邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectSameField = 3060045

        ''' <summary>
        '''���C���t�H�[����񂪈ُ�ł��B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        MainFormInfoException = 3060046

        ''' <summary>
        '''���C���t�H�[�����ڏ�񂪈ُ�ł��B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        MainFormFieldInfoException = 3060047

        ''' <summary>
        '''�w�肳�ꂽ�r���[�̏�񂪈ُ�ł��B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewInfoException = 3060048

        ''' <summary>
        '''�w�肳�ꂽ�r���[�̍��ڏ�񂪈ُ�ł��B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewFieldInfoException = 3060049

        ''' <summary>
        '''�r���[SQL�����݂��܂���
        ''' </summary>
        ''' <remarks></remarks>
        ViewSqlNotExisted = 3060050

        ''' <summary>
        '''DBGUI�ŗL���̐ݒ�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SetDBGUIFailed = 3060051

        ''' <summary>
        '''�w�肳�ꂽ�t�H�[���h�c�̃f�[�^�����݂��܂���B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        FormIdDataNotExisted = 3060052

        ''' <summary>
        '''�t�B�[���h���̎擾�Ɏ��s���܂���
        ''' </summary>
        ''' <remarks></remarks>
        GetFieldInfoFailed = 3060053

        ''' <summary>
        '''���ڂ��ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ItemIsNotSetUp = 3060054

        ''' <summary>
        '''���ڂ̐ݒ肪��肪����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ItemSetError = 3060055

        ''' <summary>
        '''�����l��YYYY/MM/DD�̌`���œ��͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        DateTypeError = 3060056

        ''' <summary>
        '''�����l�͐��l�œ��͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NumberTypeError = 3060057

        ''' <summary>
        '''�̔ԍ��ڂɎw��\�ȍ��ڂ�20���ڂ܂łł��B
        ''' </summary>
        ''' <remarks></remarks>
        ItemOverflow = 3060058

        ''' <summary>
        '''�̔ԍ��ڂ̍폜�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DelSeqitem = 3060059

        ''' <summary>
        '''���l����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        illegalInput = 3060060

        ''' <summary>
        '''�v�Z����ݒ肵�Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotExpress = 3060061

        ''' <summary>
        '''�o�͍��ڂ�I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotOutputitem = 3060062

        ''' <summary>
        '''�v�Z���̐ݒ�Ɍ�肪����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ExpressCheckError = 3060063

        ''' <summary>
        '''�v�Z���̐ݒ�Ɍ�肪����܂��B{1}����{0}�͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotFieldInExpress = 3060064

        ''' <summary>
        '''��r������ǉ����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotAddCheckCondition = 3060065

        ''' <summary>
        '''��r���ڂ�I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotCompareItem = 3060066

        ''' <summary>
        '''��r����I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotCompareItem2 = 3060067

        ''' <summary>
        '''��r���Z�q��I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotOperator = 3060068

        ''' <summary>
        '''���b�Z�[�W����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotMessage = 3060069

        ''' <summary>
        '''��r���ڂƔ�r�����d�����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        HaveSameItems = 3060070

        ''' <summary>
        '''���ځu{0}�v�͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FieldDeleted = 3060071

        ''' <summary>
        ''' ��r����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CompareSrcSelect = 3060072

        ''' <summary>
        ''' ������t����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotFixDate = 3060073

        ''' <summary>
        ''' �J�n���t����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotStartDate = 3060074

        ''' <summary>
        ''' �I�����t����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotEndDate = 3060075

        ''' <summary>
        ''' �J�n���t���I�����t�𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        EndDateError = 3060076

        ''' <summary>
        ''' ���Z���t�̒P�ʂ�I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotUnit = 3060077

        ''' <summary>
        ''' �����ݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotBunki = 3060078

        ''' <summary>
        ''' ���������ݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotCondition = 3060079

        ''' <summary>
        ''' �r���[���I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        UnSelectedView = 3060080

        ''' <summary>
        ''' �������ڂ̑g�ݍ��킹�͓�ȏ�o�^�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CannotMultiEntry = 3060081

        ''' <summary>
        ''' �f�[�^�^�C�v���قȂ邽�ߓo�^�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotEntryDiffField = 3060082

        ''' <summary>
        ''' ���������ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoSettingsCompare = 3060083

        ''' <summary>
        ''' �\�����ڂ��ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoSettingsDispField = 3060084

        ''' <summary>
        ''' �����l���ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoSettingsDefValue = 3060085

        ''' <summary>
        ''' �\��������1�ȏ�̐�������͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        MustInputOver1 = 3060086

        ''' <summary>
        ''' ������񂪏d�����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DupAuthInfo = 3060087

        ''' <summary>
        '''�Ј��R�[�h��I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NoUserIDFLD = 3060088
    End Enum

#End Region

#Region " VJNJ "

    ''' <summary>
    ''' VJNJ �v���W�F�N�g�̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VJNJ]

        ''' <summary>
        ''' �p�X���[�h����v���܂���B
        ''' </summary>
        CommonMsg0001 = 3070001

        ''' <summary>
        ''' �\�������ɂ� 0 �ȏ�̔��p��������͂��Ă��������B
        ''' </summary>
        CommonMsg0002 = 3070002

        ''' <summary>
        ''' ��E��I�����Ă��������B
        ''' </summary>
        AffiliationMsg0001 = 3071001

        ''' <summary>
        ''' �{���܂��͌�����I�����Ă��������B
        ''' </summary>
        AffiliationMsg0002 = 3071002

        ''' <summary>
        ''' �L���������t�ɗL���J�n���t��菬���ȓ��t��I�����邱�Ƃ͂ł��܂���B
        ''' </summary>
        AffiliationMsg0003 = 3071003

        ''' <summary>
        ''' ����������������Ă��Ȃ���E���������蓖�Ă��Ă��܂��B
        ''' </summary>
        AffiliationMsg0004 = 3071004

        ''' <summary>
        ''' ��E���o�^����Ă��Ȃ����߁A������ݒ肷�邱�Ƃ��ł��܂���B
        ''' ������ݒ肷�邽�߂ɂ͖�E��o�^���Ă��������B
        ''' </summary>
        AffiliationMsg0005 = 3071005

        ''' <summary>
        ''' �l�̗��p�I�����t�ȍ~�ɏ����̗L���J�n���t��ݒ肷�邱�Ƃ͂ł��܂���B
        ''' </summary>
        AffiliationMsg0006 = 3071006

        ''' <summary>
        ''' �g�D�̗L���J�n���t�� {0} �̂��߁A���p�I�����t�� {1} �̌l�������ɒǉ����邱�Ƃ͂ł��܂���B
        ''' </summary>
        AffiliationMsg0007 = 3071007

        ''' <summary>
        ''' �g�D�̗L���������t�� {0} �̂��߁A���p�J�n���t�� {1} �̌l�������ɒǉ����邱�Ƃ͂ł��܂���B
        ''' </summary>
        AffiliationMsg0008 = 3071008

        ''' <summary>
        ''' �l�̗��p�J�n���t�� {0} �̂��߁A�L���������t�� {1} �̑g�D�������ɒǉ����邱�Ƃ͂ł��܂���B
        ''' </summary>
        AffiliationMsg0009 = 3071009

        ''' <summary>
        ''' �l�̗��p�I�����t�� {0} �̂��߁A�L���J�n���t�� {1} �̑g�D�������ɒǉ����邱�Ƃ͂ł��܂���B
        ''' </summary>
        AffiliationMsg0010 = 3071010

        ''' <summary>
        ''' �I����������͌������[�g�̃J�e�S���ɐݒ肳��Ă��邽�ߍ폜���邱�Ƃ��ł��܂���B
        ''' </summary>
        BranchMsg0001 = 3072001

        ''' <summary>
        ''' �L���������t�ɗL���J�n���t��菬���ȓ��t��I�����邱�Ƃ͂ł��܂���B
        ''' </summary>
        GroupMsg0001 = 3073001

        ''' <summary>
        ''' �g�D�E�O���[�v��ʂ�I�����Ă��������B
        ''' </summary>
        GroupMsg0002 = 3073002

        ''' <summary>
        ''' �g�D�E�O���[�v�R�[�h����͂��Ă��������B
        ''' </summary>
        GroupMsg0003 = 3073003

        ''' <summary>
        ''' �g�D�E�O���[�v������͂��Ă��������B
        ''' </summary>
        GroupMsg0004 = 3073004

        ''' <summary>
        ''' �\������ 0 �ȏ�̐��̐�������͂��Ă��������B
        ''' </summary>
        GroupMsg0005 = 3073005

        ''' <summary>
        ''' Windows �A�J�E���g�̃h���C���������͂���Ă��܂���Q�ƃ{�^�����O���[�v��I�����Ă��������B
        ''' </summary>
        GroupMsg0006 = 3073006

        ''' <summary>
        ''' Windows �A�J�E���g�̃O���[�v�������͂���Ă��܂���Q�ƃ{�^�����O���[�v��I�����Ă��������B
        ''' </summary>
        GroupMsg0007 = 3073007

        ''' <summary>
        ''' ���͂��ꂽ�g�D�E�O���[�v�R�[�h�͑��̑g�D�E�O���[�v�ɂ����Ɏg�p����Ă��܂��B
        ''' </summary>
        GroupMsg0008 = 3073008

        ''' <summary>
        ''' ��ʑg�D�E�O���[�v�̗L���J�n���t�� {0} �ł��B
        ''' ����ȑO�̗L���J�n���t�����g�D�E�O���[�v��o�^���邱�Ƃ͂ł��܂���B
        ''' </summary>
        GroupMsg0009 = 3073009

        ''' <summary>
        ''' ��ʑg�D�E�O���[�v�̗L���������t�� {0} �ł��B
        ''' ����ȍ~�̗L���J�n���t�����g�D�E�O���[�v��o�^���邱�Ƃ͂ł��܂���B
        ''' </summary>
        GroupMsg0010 = 3073010

        ''' <summary>
        ''' ��ʑg�D�E�O���[�v�̗L���������t�� {0} �ł��B
        ''' ����ȍ~�̗L���������t�����g�D�E�O���[�v��o�^���邱�Ƃ͂ł��܂���B
        ''' </summary>
        GroupMsg0011 = 3073011

        ''' <summary>
        ''' �O���[�v�̔z���ɑg�D���쐬���邱�Ƃ͂ł��܂���B
        ''' </summary>
        GroupMsg0012 = 3073012

        ''' <summary>
        ''' �z���ɑg�D�����݂��邽�߁A�g�D�E�O���[�v��ʂ�g�D����O���[�v�ɕύX���邱�Ƃ͂ł��܂���B
        ''' �g�D�E�O���[�v��ʂ�ύX����ɂ́A���ʂ̑g�D���폜���邩�O���[�v�ɕύX���Ă��������B
        ''' </summary>
        GroupMsg0013 = 3073013

        ''' <summary>
        ''' �z���ɏ��������݂��邽�߁A�g�D�E�O���[�v��ʂ�ύX���邱�Ƃ͂ł��܂���B
        ''' �g�D�E�O���[�v��ʂ�ύX����ɂ́A���ׂĂ̏������폜���Ă���s���Ă��������B
        ''' </summary>
        GroupMsg0014 = 3073014

        ''' <summary>
        ''' �g�D�E�O���[�v�R�[�h�͔��p�p�����œ��͂��Ă��������B
        ''' </summary>
        GroupMsg0015 = 3073015

        ''' <summary>
        ''' �l�R�[�h����͂��Ă��������B
        ''' </summary>
        PersonMsg0001 = 3074001

        ''' <summary>
        ''' ��������͂��Ă��������B
        ''' </summary>
        PersonMsg0002 = 3074002

        ''' <summary>
        ''' �����i�J�i�j����͂��Ă��������B
        ''' </summary>
        PersonMsg0003 = 3074003

        ''' <summary>
        ''' ���p�I�����t�ɗ��p�J�n���t����菬���ȓ��t��I�����邱�Ƃ͂ł��܂���B
        ''' </summary>
        PersonMsg0004 = 3074004

        ''' <summary>
        ''' ���[�U�[�h�c����͂��Ă��������B
        ''' </summary>
        PersonMsg0005 = 3074005

        ''' <summary>
        ''' �p�X���[�h����͂��Ă��������B
        ''' </summary>
        PersonMsg0006 = 3074006

        ''' <summary>
        ''' �p�X���[�h����v���܂���B�p�X���[�h�𗼕��̃e�L�X�g�{�b�N�X�ɓ��͂��Ă��������B
        ''' </summary>
        PersonMsg0007 = 3074007

        ''' <summary>
        ''' �h���C���������͂���Ă��܂���B�Q�ƃ{�^����胆�[�U�[��I�����Ă��������B
        ''' </summary>
        PersonMsg0008 = 3074008

        ''' <summary>
        ''' ���[�U�[�h�c�����͂���Ă��܂���B�Q�ƃ{�^����胆�[�U�[��I�����Ă��������B
        ''' </summary>
        PersonMsg0009 = 3074009

        ''' <summary>
        ''' ��ӂ����͂���Ă��܂���B
        ''' </summary>
        PersonMsg0010 = 3074010

        ''' <summary>
        ''' ���͂��ꂽ�l�R�[�h�͑��̃��[�U�[�ɂ����Ɏg�p����Ă��܂��B
        ''' </summary>
        PersonMsg0011 = 3074011

        ''' <summary>
        ''' ���[���A�h���X�̌`��������������܂���B
        ''' </summary>
        PersonMsg0012 = 3074012

        ''' <summary>
        ''' ���[�U�[�h�c�ɋ֑��������܂܂�Ă��܂��B
        ''' ���̕����̓��[�U�[���Ɏg�p���邱�Ƃ͂ł��܂���B
        ''' </summary>
        PersonMsg0013 = 3074013

        ''' <summary>
        ''' ���͂��ꂽ���[�U�[�h�c�͑��̃��[�U�[�ɂ����Ɏg�p����Ă��܂��B
        ''' </summary>
        PersonMsg0014 = 3074014

        ''' <summary>
        ''' �l�R�[�h�͔��p�p�����œ��͂��Ă��������B
        ''' </summary>
        PersonMsg0015 = 3074015

        ''' <summary>
        ''' ���[�U�[�h�c�͔��p�p������юg�p��������Ă���L���œ��͂��Ă��������B
        ''' </summary>
        PersonMsg0016 = 3074016

        ''' <summary>
        ''' �L���������t�ɗL���J�n���t��菬���ȓ��t��I�����邱�Ƃ͂ł��܂���B
        ''' </summary>
        PositionMsg0001 = 3075001

        ''' <summary>
        ''' ��E�R�[�h����͂��Ă��������B
        ''' </summary>
        PositionMsg0002 = 3075002

        ''' <summary>
        ''' ��E������͂��Ă��������B
        ''' </summary>
        PositionMsg0003 = 3075003

        ''' <summary>
        ''' ��E��ʂ�I�����Ă��������B
        ''' </summary>
        PositionMsg0004 = 3075004

        ''' <summary>
        ''' �\������ 0 �ȏ�̐��̐�������͂��Ă��������B
        ''' </summary>
        PositionMsg0005 = 3075005

        ''' <summary>
        ''' ���͂��ꂽ��E�R�[�h�͑��̖�E�ɂ����Ɏg�p����Ă��܂��B
        ''' </summary>
        PositionMsg0006 = 3075006

        ''' <summary>
        ''' �������x���� 0 �ȏ�̐��̐�������͂��Ă��������B
        ''' </summary>
        PositionMsg0007 = 3075007

        ''' <summary>
        ''' ��E�R�[�h�͔��p�p�����œ��͂��Ă��������B
        ''' </summary>
        PositionMsg0008 = 3075008

        ''' <summary>
        ''' �㗝������I�����Ă��������B
        ''' </summary>
        ProxyMsg0001 = 3076001

        ''' <summary>
        ''' �L���������t�ɗL���J�n���t��菬���ȓ��t��I�����邱�Ƃ͂ł��܂���B
        ''' </summary>
        ProxyMsg0002 = 3076002

        ''' <summary>
        ''' ���ꃆ�[�U�[�œ����㗝������I�����邱�Ƃ͂ł��܂���B
        ''' </summary>
        ProxyMsg0003 = 3076003

        ''' <summary>
        ''' �g�D�܂��O���[�v��I�����邱�Ƃ͂ł��܂���B
        ''' </summary>
        MuitlSelMsg01 = 3076004

        ''' <summary>
        ''' ���[�U�[���d�����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        MuitlSelMsg02 = 3076005

    End Enum

#End Region

#Region " VMNU "

    ''' <summary>
    ''' VMNU �v���W�F�N�g�̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VMNU]

        '''' <summary>
        '''' ���͂������[�U�[�����݂��܂���B
        '''' </summary>
        '''' <remarks></remarks>
        'LoginNoUser = 3080001


        '''' <summary>
        '''' ���͂����p�X���[�h������������܂���B
        '''' </summary>
        '''' <remarks></remarks>
        'LoginUnPass = 3080002

        ''' <summary>
        ''' �ҏW����������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoAuth = 3080003

        '''' <summary>
        '''' AD�F�؂Ɏ��s���܂����B
        '''' </summary>
        '''' <remarks></remarks>
        'LoginNoAd = 3080004

        ''' <summary>
        ''' ����������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        LoginNotBelong = 3080005

        '''' <summary>
        '''' AD�F�؎����[�J�����O�C���ł���̂͊Ǘ��҂݂̂ł��B
        '''' </summary>
        '''' <remarks></remarks>
        'LoginAdLoacal = 3080006

        ''' <summary>
        ''' �g�D���ҏ������������Ȃ���Ԃŉ��ғ����}���Ă��邽�߁A���O�C���ł��܂���B{0}���O�C���ł���̂͊Ǘ��҂݂̂ł��B
        ''' </summary>
        ''' <remarks></remarks>
        LoginDateInReorganization = 3080007

        ''' <summary>
        ''' �g�D���ҏ������������Ȃ���Ԃŉ��ғ����}���Ă��邽�߁A���O�C���ł��܂���B{0}�Ǘ��҂ɖ₢���킹�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        LoginDateInReorganizationByWeb = 3080008

        ''' <summary>
        ''' ���[�U�[�����擾�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoUserInformation = 3080009

        ''' <summary>
        ''' �������Q�Ƃ��錠�����ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoReadDocPermission = 3080010

        ''' <summary>
        ''' ���[�����󂯎�����̂Ɠ����Ј��ԍ���Windows�փ��O�C�����Ȃ����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoMatchMailUser = 3080011

        ''' <summary>
        ''' �{�l�̃J�[�h���g�p���邩�A�{�l�̎Ј��ԍ���Windows�փ��O�C�����Ȃ����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoMatchGAUser = 3080012

        ''' <summary>
        '''�w�肳�ꂽ�t�H�[�����Q�Ƃ��錠�����ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoShowFormPermission = 3080013


        ''' <summary>
        '''�ٓ��Ȃǂ̗��R�ɂ�蕶�����J���������Ȃ��Ȃ��Ă��܂��B{0} �Ɩ���K�v�ȏꍇ�͊Ǘ��҂܂ł��A���������B
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoSysBlg = 3080014

        ''' <summary>
        '''�L���r�l�b�g�̃p�X���[�h����v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotCabPass = 3080015


        ''' <summary>
        '''�L���r�l�b�g�p�X���[�h������������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MissCabPass = 3080016

        ''' <summary>
        '''�������J�n��(����)����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MooVltrmstChk = 3080017


        ''' <summary>
        '''���l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MooVltrmstNMChk = 3080018


        ''' <summary>
        '''�����̂���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MooNmtrmChk = 3080019


        ''' <summary>
        '''�J�n�����A�d�����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        MooVltrmstDupChk = 3080020

        ''' <summary>
        '''�����̂��A�d�����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        MooNmtrmDupChk = 3080021

        ''' <summary>
        '''�Ώۓ��𐳂������t�œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        DayHolidayChk = 3080022

        ''' <summary>
        '''�Ώۓ����J�����_�[����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        DayHolidayChk2 = 3080023

        ''' <summary>
        '''�Ώۃf�[�^���ꌏ������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DayNotData = 3080024

        ''' <summary>
        '''�N����No����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        YerNoNull = 3080025

        ''' <summary>
        '''�N���̖��̂���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        YerNMERANull = 3080026

        ''' <summary>
        '''�N���̊J�n���t����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        YerVLSTDateChk = 3080027

        ''' <summary>
        '''�N���̏I�����t����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        YerEraVLEDDateChk = 3080028

        ''' <summary>
        '''�P�y�[�W�\����������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ViewCountChk = 3080029

        ''' <summary>
        '''�������ő�\����������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ViewMaxCountChk = 3080030

        ''' <summary>
        '''��Ɨp�z���_�[����͂��ĉ������B{0}{0}�ő�P�O�O�O�܂Őݒ�\�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        RidocWorkFolderChk = 3080031

        ''' <summary>
        '''���[���T�[�o�[����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MailServerChk = 3080032

        ''' <summary>
        '''IIS�T�[�o�[����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        IISServerAddChk = 3080033

        ''' <summary>
        '''AD�g�p���[�U�擾�h���C��������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        AdUseDomainUserChk = 3080034

        ''' <summary>
        '''AD�g�p�O���[�v�擾�h���C��������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        AdUseDomainGrpChk = 3080035

        ''' <summary>
        '''DB�ڑ����������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        DbConnectStringChk = 3080036

        ''' <summary>
        '''���O��������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        LogLifeChk = 3080037

        ''' <summary>
        '''�Ǘ��҃p�X���[�h�𐳂������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        AdminiPassChk = 3080038

        ''' <summary>
        '''�V�X�e���J�n���t�𐳂������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        AdminYDMChk = 3080039

        ''' <summary>
        '''���ڂ𐳂������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        InCreChk = 3080040

        ''' <summary>
        '''�Ǘ��V�X�e���͑��̃��[�U���g�p���ł��B{0}�A�v���P�[�V�������I�����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        UsedAnotherUser = 3080041

        ''' <summary>
        '''�J�n���͂P�`�P�Q�̐����œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MonthOutOfRange = 3080042

        ''' <summary>
        '''�J�n���𐳂������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        TermOutOfRange = 3080043

        ''' <summary>
        '''���O�ۑ���������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        LogLifeMustInput = 3080044

        ''' <summary>
        '''���O�ۑ������͐��l���ڂł��B
        ''' </summary>
        ''' <remarks></remarks>
        LogLifeNumericOnly = 3080045

        ''' <summary>
        '''���O�ۑ������𐳂������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        LogLifeArgumentOutOfRange = 3080046

        ''' <summary>
        '''���[���A�h���X�E���̂���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MailAddressMustInput = 3080047

        ''' <summary>
        '''���[���T�[�o�[����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MailServerMustInput = 3080048

        ''' <summary>
        '''�P�y�[�W�̕\����������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        DocCountMustInput = 3080049

        ''' <summary>
        '''�P�y�[�W�̕\�������͐��l���ڂł��B
        ''' </summary>
        ''' <remarks></remarks>
        DocCountNumericOnly = 3080050

        ''' <summary>
        '''�P�y�[�W�̕\�������𐳂������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        DocCountArgumentOutOfRange = 3080051

        ''' <summary>
        '''�ő�\����������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MaxCountMustInput = 3080052

        ''' <summary>
        '''�ő�\�������͐��l���ڂł��B
        ''' </summary>
        ''' <remarks></remarks>
        MaxCountNumericOnly = 3080053

        ''' <summary>
        '''�ő�\�������𐳂������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MaxCountArgumentOutOfRange = 3080054

        ''' <summary>
        '''�ő�\��������1000���ȏ�͎w��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MaxCountOverflow = 3080055


        ''' <summary>
        '''�쐬�̍��ږ�����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ActionMakeMustInput = 3080056


        ''' <summary>
        '''�R���̍��ږ�����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ActionAcceptMustInput = 3080057


        ''' <summary>
        '''���F�̍��ږ�����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ActionSubmitMustInput = 3080058

        ''' <summary>
        '''�۔F�̍��ږ�����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ActionDenyMustInput = 3080059
        ''' <summary>
        '''���߂��̍��ږ�����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ActionRemandMustInput = 3080060

        ''' <summary>
        '''�쐬�����̍��ږ�����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MakeButtonCaptionMustInput = 3080061

        ''' <summary>
        '''�R�����ׂ������̍��ږ�����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        AcceptButtonCaptionMustInput = 3080062

        ''' <summary>
        '''�ꊇ�R���̍��ږ�����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        AllAcceptButtonCaptionMustInput = 3080063

        ''' <summary>
        '''���F���ׂ������̍��ږ�����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        SubmitButtonCaptionMustInput = 3080064

        ''' <summary>
        '''���߂������̍��ږ�����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RemandButtonCaptionMustInput = 3080065

        ''' <summary>
        '''�쐬���̉񗗏�Ԃ���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CircularDraftMustInput = 3080066

        ''' <summary>
        '''���F�҂��̉񗗏�Ԃ���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CircularAcceptMustInput = 3080067

        ''' <summary>
        '''���F�̉񗗏�Ԃ���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CircularSubmitMustInput = 3080068

        ''' <summary>
        '''�۔F�̉񗗏�Ԃ���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CircularDenyMustInput = 3080069

        ''' <summary>
        '''���߂��̉񗗏�Ԃ���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CircularRemandMustInput = 3080070

        ''' <summary>
        '''�������̉񗗏�Ԃ���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        CircularDraftRevisionMustInput = 3080071

        ''' <summary>
        '''�f�[�^�œK���̊J�n���Ԃ���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        SwatHourMustInput = 3080072

        ''' <summary>
        '''�e�[�^�œK���̊J�n���Ԃ͐��l���ڂł��B
        ''' </summary>
        ''' <remarks></remarks>
        SwatHourNumericOnly = 3080073

        ''' <summary>
        '''�f�[�^�œK���̊J�n���Ԃ𐳂������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        SwatHourArgumentOutOfRange = 3080074

        ''' <summary>
        '''�f�[�^�œK���̊J�n���Ԃ���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        SwatMinuteMustInput = 3080075

        ''' <summary>
        '''�e�[�^�œK���̊J�n���Ԃ͐��l���ڂł��B
        ''' </summary>
        ''' <remarks></remarks>
        SwatMinuteNumericOnly = 3080076

        ''' <summary>
        '''�f�[�^�œK���̊J�n���Ԃ𐳂������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        SwatMinuteArgumentOutOfRange = 3080077

        ''' <summary>
        '''�ؗ������J�n���Ԃ���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RetentionHourMustInput = 3080078

        ''' <summary>
        '''�ؗ������J�n���Ԃ͐��l���ڂł��B
        ''' </summary>
        ''' <remarks></remarks>
        RetentionHourNumericOnly = 3080079

        ''' <summary>
        '''�ؗ������J�n���Ԃ𐳂������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RetentionHourArgumentOutOfRange = 3080080

        ''' <summary>
        '''�ؗ������J�n���Ԃ���͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RetentionMinuteMustInput = 3080081

        ''' <summary>
        '''�ؗ������J�n���Ԃ͐��l���ڂł��B
        ''' </summary>
        ''' <remarks></remarks>
        RetentionMinuteNumericOnly = 3080082

        ''' <summary>
        '''�ؗ������J�n���Ԃ𐳂������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RetentionMinuteArgumentOutOfRange = 3080083

        ''' <summary>
        '''�p�X���[�h����v���܂���B{0}�����ɐV�����p�X���[�h����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        TwoPasswordDonotMuch = 3080084

        ''' <summary>
        '''�V�X�e���J�n���t���s���ł��B{0}���������t����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        UnknownSystemDate = 3080085

        ''' <summary>
        '''�S�Е\��������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ZensyaDispMustInput = 3080086

        ''' <summary>
        '''�e�Ǖ\��������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        KakukyokuDispMustInput = 3080087

        ''' <summary>
        '''�����A�g�D���Ғ��ł��B���΂炭�o������A�ēx���s���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3080088

        ''' <summary>
        '''�捞�Ώۂ̃t�@�C�������݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectedDenpo = 3080089

        ''' <summary>
        '''�捞�Ώۂ̃t�@�C��������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectDenpoFile = 3080090

        ''' <summary>
        '''�捞�v���O�������I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectDenpo = 3080091

        ''' <summary>
        '''�d�񔭍s�Ɏg�p����t�@�C����葽���ݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        SelectDenpoFileNo = 3080092


        ''' <summary>
        '''�̔� �l���捞�v���O���������݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonProgramMessage = 3080093

        ''' <summary>
        '''���[���̌�������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NonSubjectMessage = 3080094

        ''' <summary>
        '''���[���̓��e����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NonBodyMessage = 3080095

        ''' <summary>
        '''�ݒ�l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NonValueMessage = 3080096

        ''' <summary>
        '''�A�J�E���g�����b�N����܂ł̉񐔂��s���ł��B{0}�P��ȏ����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ViolationAccountLockNumber = 3080097

        ''' <summary>
        '''�L�������̌������s���ł��B{0}�P�����ȏ����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ViolationLimitNumber = 3080098

        ''' <summary>
        '''�p�X���[�h���̍ŏ��������s���ł��B{0}�P�����ȏ�20�����ȉ���ݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ViolationMinLengthPassword = 3080099

        ''' <summary>
        '''�p�X���[�h���̍ő包�����s���ł��B{0}�P�����ȏ�20�����ȉ���ݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ViolationMaxLengthPassword = 3080100

        ''' <summary>
        '''�p�X���[�h���̍ŏ������ƍő包���̒l���s���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        ViolationMinMaxLengthPassword = 3080101

        ''' <summary>
        '''���ꕶ���̌J�Ԃ��񐔂��s���ł��B{0}�P�����ȏ����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ViolationRepeatCharPassword = 3080102

        ''' <summary>
        '''�p�X���[�h�̗����񐔂��s���ł��B{0}�P��ȏ����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ViolationHistoryPassword = 3080103

        ''' <summary>
        '''�֑���������͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        ViolationWrapString = 3080104

        ''' <summary>
        '''�ڑ���̃T�[�o�[���ݒ肳��Ă��܂���B{0}���ݒ��菉���ݒ���s���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        ServerWasNotSet = 3080105

        ''' <summary>
        ''' ���[�U�[�h�c����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        InputLoginUser = 3080106

        ''' <summary>
        ''' �p�X���[�h����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        InputPassword = 3080107

        ''' <summary>
        ''' ���񌎂�ύX���܂��B
        ''' �o�^���Ă��Ȃ��x���ݒ�͖����ɂȂ�܂��B
        ''' </summary>
        ''' <remarks></remarks>
        StartMonthChange = 3080108

        ''' <summary>
        ''' �T�[�o�[��I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        SelectServer = 3080109

        ''' <summary>
        ''' �h���C����I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        SelectDomain = 3080110

        ''' <summary>
        ''' ���[�UID�܂��̓p�X���[�h���Ԉ���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        LoginFailed = 3080111

        ''' <summary>
        ''' �w�肵���t�H�[�������J����ĂȂ��B
        ''' </summary>
        ''' <remarks></remarks>
        FormNotPublic = 3080112

        ''' <summary>
        ''' �L�[���[�h����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotInputKeyword = 3080113

        ''' <summary>
        ''' �P�ꂪ�ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        WordEmpty = 3080114

        ''' <summary>
        ''' �L�[���[�h�͊��ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ExistKeyword = 3080115

    End Enum

#End Region

#Region " VRTE "

    ''' <summary>
    ''' VRTE �v���W�F�N�g�̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRTE]

        ''' <summary>
        ''' �f�t�H���g���[�g�͍폜�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE001 = 3090001

        ''' <summary>
        ''' ���͂��ꂽ�l������������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE002 = 3090002

        ''' <summary>
        ''' �N�ă��[�g�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE003 = 3090003

        ''' <summary>
        ''' ��������ŏI��郋�[�g�͍쐬�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE004 = 3090004

        ''' <summary>
        ''' �\���ł���̂́A�N�ă��[�g�Ȃ�тɊK�w���[�g�̐l�����ł��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE005 = 3090005

        ''' <summary>
        ''' �N�ă��[�g�Ɋ֘A�t���͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE006 = 3090006

        ''' <summary>
        ''' �N�ă��[�g�����ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE007 = 3090007

        ''' <summary>
        ''' ��E��A���F�����Ȃ��̏ꍇ�͋N�ă��[�g�̂ݐݒ�ł��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE008 = 3090008

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE009 = 3090009

        ''' <summary>
        ''' ��������Ɋ֘A�t�����Ă��邽�߁A���[�g�P�̂ɂ͊֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE010 = 3090010

        ''' <summary>
        ''' �O���[�v���܂߂����s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE011 = 3090011

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE012 = 3090012

        ''' <summary>
        ''' �e���[�g�����ɑ��̏��F���Ɋ��蓖�Ă��Ă��邽�߁A�֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE013 = 3090013

        ''' <summary>
        ''' �e���[�g�ɏ������򂪊��蓖�Ă��Ă��邽�߁A���[�g�P�̂��֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE014 = 3090014

        ''' <summary>
        ''' �N�ă��[�g�Ɋ֘A�t���͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE015 = 3090015

        ''' <summary>
        ''' �N�ă��[�g�����ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE016 = 3090016

        ''' <summary>
        ''' ��E��A���F�����Ȃ��̏ꍇ�͋N�ă��[�g�̂ݐݒ�ł��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE017 = 3090017

        ''' <summary>
        ''' �O���[�v���܂߂����s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE018 = 3090018

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE019 = 3090019

        ''' <summary>
        ''' ��������Ɋ֘A�t�����Ă��邽�߁A���[�g�P�̂ɂ͊֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE020 = 3090020

        ''' <summary>
        ''' �O���[�v���܂߂����s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE021 = 3090021

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE022 = 3090022

        ''' <summary>
        ''' �e���[�g�����ɑ��̏��F���Ɋ��蓖�Ă��Ă��邽�߁A�֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE023 = 3090023

        ''' <summary>
        ''' �e���[�g�ɏ������򂪊��蓖�Ă��Ă��邽�߁A���[�g�P�̂��֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE024 = 3090024

        ''' <summary>
        ''' �N�ă��[�g�����ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE025 = 3090025

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE026 = 3090026

        ''' <summary>
        ''' ��������Ɋ֘A�t�����Ă��邽�߁A���[�g�P�̂ɂ͊֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE027 = 3090027

        ''' <summary>
        ''' ��������̕��s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE028 = 3090028

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE029 = 3090029

        ''' <summary>
        ''' �e���[�g�����ɑ��̏��F���Ɋ��蓖�Ă��Ă��邽�߁A�֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE030 = 3090030

        ''' <summary>
        ''' �N�ă��[�g�Ɋ֘A�t���͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE031 = 3090031

        ''' <summary>
        ''' ��E��A���F�����Ȃ��̏ꍇ�͋N�ă��[�g�̂ݐݒ�ł��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE032 = 3090032

        ''' <summary>
        ''' �������򂩂�O���[�v�ւ̐ݒ�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE033 = 3090033

        ''' <summary>
        ''' ��������i�^�j�̎q���[�g�͊��ɐݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE034 = 3090034

        ''' <summary>
        ''' ��������i�U�j�̎q���[�g�͊��ɐݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE035 = 3090035

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE036 = 3090036

        ''' <summary>
        ''' ��������i�^�j�̎q���[�g�͊��ɐݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE037 = 3090037

        ''' <summary>
        ''' ��������i�U�j�̎q���[�g�͊��ɐݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE038 = 3090038

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE039 = 3090039

        ''' <summary>
        ''' �N�ă��[�g�͕ύX�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE040 = 3090040

        ''' <summary>
        ''' �N�ă��[�g�͕ύX�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE041 = 3090041

        ''' <summary>
        ''' �I�����ꂽ�g�D�ɑg�D��񂪑��݂��܂���B�v���O�������ċN�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE042 = 3090042

        ''' <summary>
        ''' �g�D�E�O���[�v��I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE043 = 3090043

        ''' <summary>
        ''' ���p�O���[�v��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE044 = 3090044

        ''' <summary>
        ''' �J�e�S�����I������Ă��܂��B�t�H�[����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE045 = 3090045

        ''' <summary>
        ''' ����t�H�[���͑I���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE046 = 3090046

        ''' <summary>
        ''' �폜����t�H�[����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE047 = 3090047

        ''' <summary>
        ''' ���[�g������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE048 = 3090048

        ''' <summary>
        ''' ���[�g�J�n���t�����[�g�I�����t��薢���ɐݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE049 = 3090049

        ''' <summary>
        ''' ���ɓo�^�ς݂ł��B�ʂ̍��ڂ�o�^���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE050 = 3090050

        ''' <summary>
        ''' �Ō�̏��F�҂́A�\��������t�^�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE051 = 3090051

        ''' <summary>
        ''' �Ō�̏��F�҂́A��z��������t�^�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE052 = 3090052

        ''' <summary>
        ''' �������򂪐ݒ肳��Ă���ꍇ�́A��z��������t�^�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE053 = 3090053

        ''' <summary>
        ''' ���s���F���ݒ肳��Ă���ꍇ�́A��z��������t�^�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE054 = 3090054

        ''' <summary>
        ''' ��������ɏ������ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE055 = 3090055

        ''' <summary>
        ''' �������I�[�o�[���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE056 = 3090056

        ''' <summary>
        ''' ���l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE057 = 3090057

        ''' <summary>
        ''' yyyy/mm/dd�`���œ��t����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE058 = 3090058

        ''' <summary>
        ''' �K�{���ڂł��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE059 = 3090059

        ''' <summary>
        ''' �ŏI���F�ł̕��s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE060 = 3090060

        ''' <summary>
        ''' ���s���F�ł̓����E�����蓖�Ă邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE061 = 3090061

        ''' <summary>
        ''' �֘A�t���Ă��Ȃ����[�g�����݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE062 = 3090062

        ''' <summary>
        ''' �����͈̔͂��I�[�o�[���Ă܂��B{0}922,337,203,685,477.5807 �` -922,337,203,685,477.5808�͈̔͂œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE063 = 3090063

        ''' <summary>
        ''' �����͈̔͂��I�[�o�[���Ă܂��B{0}2,147,483,647 �` -2,147,483,648�͈̔͂œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE064 = 3090064

        ''' <summary>
        ''' �����̓��͂͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE065 = 3090065

        ''' <summary>
        ''' �g�D�Ɩ�E���N�Ď҂Ɠ������[�g�͎w��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE066 = 3090066

        ''' <summary>
        ''' �{�l�͋N�ă��[�g�Ɏw��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE067 = 3090067

        ''' <summary>
        ''' �쐬�҃��[�g�ȊO�N�ă��[�g�Ɏw��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE068 = 3090068

        ''' <summary>
        ''' �{�l���܂߂����s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE069 = 3090069

        ''' <summary>
        ''' ����l���̕��s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE070 = 3090070

        ''' <summary>
        ''' ��������������͕������F��̐\���敪�͐ݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE071 = 3090071

        ''' <summary>
        ''' �֘A�t���Ă��Ȃ��������򂪑��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE072 = 3090072

        ''' <summary>
        ''' �Q�o�C�g�������܂܂�Ă��܂��B�Q�o�C�g�����͓��͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE073 = 3090073

        ''' <summary>
        ''' �����������Ă��܂��B�L��������11���܂łł��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE074 = 3090074

        ''' <summary>
        ''' �J���}�̓��͂͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE075 = 3090075

        ''' <summary>
        ''' ���͌`���Ɍ�肪����܂��B{0}-9999999999�̌`���œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE076 = 3090076

        ''' <summary>
        ''' �����ȏ������ݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE077 = 3090077

        ''' <summary>
        ''' �Q�O�o�C�g�𒴂��镶���͏�������ł͐ݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE078 = 3090078

        ''' <summary>
        ''' ���R�w����܂߂����s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE079 = 3090079

        ''' <summary>
        ''' �����A�g�D���Ғ��ł��B���΂炭�o������A�ēx���s���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3090080

        ''' <summary>
        ''' ���R�w��͋N�ă��[�g�Ɏw��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNot1stSetFreeRoute = 3090081

        ''' <summary>
        ''' ����������܂ގ��R�w�胋�[�g�͐ݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotExecuteFreeRouteWithCondition = 3090082

        ''' <summary>
        ''' ���R�w����֘A�t���邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectFreeRoute = 3090083

    End Enum

#End Region

#Region " VRUN "

    ''' <summary>
    ''' VRUN �v���W�F�N�g�̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRUN]

        ''' <summary>
        ''' �f�t�H���g���[�g�͍폜�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE001 = 3100001

        ''' <summary>
        ''' ���͂��ꂽ�l������������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE002 = 3100002

        ''' <summary>
        ''' �N�ă��[�g�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE003 = 3100003

        ''' <summary>
        ''' ��������ŏI��郋�[�g�͍쐬�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE004 = 3100004

        ''' <summary>
        ''' �\���ł���̂́A�N�ă��[�g�Ȃ�тɊK�w���[�g�̐l�����ł��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE005 = 3100005

        ''' <summary>
        ''' �N�ă��[�g�Ɋ֘A�t���͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE006 = 3100006

        ''' <summary>
        ''' �N�ă��[�g�����ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE007 = 3100007

        ''' <summary>
        ''' ��E��A���F�����Ȃ��̏ꍇ�͋N�ă��[�g�̂ݐݒ�ł��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE008 = 3100008

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE009 = 3100009

        ''' <summary>
        ''' ��������Ɋ֘A�t�����Ă��邽�߁A���[�g�P�̂ɂ͊֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE010 = 3100010

        ''' <summary>
        ''' �O���[�v���܂߂����s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE011 = 3100011

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE012 = 3100012

        ''' <summary>
        ''' �e���[�g�����ɑ��̏��F���Ɋ��蓖�Ă��Ă��邽�߁A�֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE013 = 3100013

        ''' <summary>
        ''' �e���[�g�ɏ������򂪊��蓖�Ă��Ă��邽�߁A���[�g�P�̂��֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE014 = 3100014

        ''' <summary>
        ''' �N�ă��[�g�Ɋ֘A�t���͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE015 = 3100015

        ''' <summary>
        ''' �N�ă��[�g�����ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE016 = 3100016

        ''' <summary>
        ''' ��E��A���F�����Ȃ��̏ꍇ�͋N�ă��[�g�̂ݐݒ�ł��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE017 = 3100017

        ''' <summary>
        ''' �O���[�v���܂߂����s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE018 = 3100018

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE019 = 3100019

        ''' <summary>
        ''' ��������Ɋ֘A�t�����Ă��邽�߁A���[�g�P�̂ɂ͊֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE020 = 3100020

        ''' <summary>
        ''' �O���[�v���܂߂����s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE021 = 3100021

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE022 = 3100022

        ''' <summary>
        ''' �e���[�g�����ɑ��̏��F���Ɋ��蓖�Ă��Ă��邽�߁A�֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE023 = 3100023

        ''' <summary>
        ''' �e���[�g�ɏ������򂪊��蓖�Ă��Ă��邽�߁A���[�g�P�̂��֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE024 = 3100024

        ''' <summary>
        ''' �N�ă��[�g�����ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE025 = 3100025

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE026 = 3100026

        ''' <summary>
        ''' ��������Ɋ֘A�t�����Ă��邽�߁A���[�g�P�̂ɂ͊֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE027 = 3100027

        ''' <summary>
        ''' ��������̕��s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE028 = 3100028

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE029 = 3100029

        ''' <summary>
        ''' �e���[�g�����ɑ��̏��F���Ɋ��蓖�Ă��Ă��邽�߁A�֘A�t���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE030 = 3100030

        ''' <summary>
        ''' �N�ă��[�g�Ɋ֘A�t���͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE031 = 3100031

        ''' <summary>
        ''' ��E��A���F�����Ȃ��̏ꍇ�͋N�ă��[�g�̂ݐݒ�ł��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE032 = 3100032

        ''' <summary>
        ''' �������򂩂�O���[�v�ւ̐ݒ�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE033 = 3100033

        ''' <summary>
        ''' ��������i�^�j�̎q���[�g�͊��ɐݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE034 = 3100034

        ''' <summary>
        ''' ��������i�U�j�̎q���[�g�͊��ɐݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE035 = 3100035

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE036 = 3100036

        ''' <summary>
        ''' ��������i�^�j�̎q���[�g�͊��ɐݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE037 = 3100037

        ''' <summary>
        ''' ��������i�U�j�̎q���[�g�͊��ɐݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE038 = 3100038

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE039 = 3100039

        ''' <summary>
        ''' �������[�g�̋N�ă��[�g�͕ύX�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE040 = 3100040

        ''' <summary>
        ''' �������[�g�̋N�ă��[�g�͕ύX�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE041 = 3100041

        ''' <summary>
        ''' �I�����ꂽ�g�D�ɑg�D��񂪑��݂��܂���B�v���O�������ċN�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE042 = 3100042

        ''' <summary>
        ''' ���[�g���L����O���[�v�����X�g����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE043 = 3100043

        ''' <summary>
        ''' ���p�O���[�v��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE044 = 3100044

        ''' <summary>
        ''' �J�e�S�����I������Ă��܂��B�t�H�[����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE045 = 3100045

        ''' <summary>
        ''' ����t�H�[���͑I���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE046 = 3100046

        ''' <summary>
        ''' �폜����t�H�[����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE047 = 3100047

        ''' <summary>
        ''' ���[�g������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE048 = 3100048

        ''' <summary>
        ''' ���[�g�J�n���t�����[�g�I�����t��薢���ɐݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE049 = 3100049

        ''' <summary>
        ''' ���ɓo�^�ς݂ł��B�ʂ̍��ڂ�o�^���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE050 = 3100050

        ''' <summary>
        ''' �Ō�̏��F�҂́A�\��������t�^�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE051 = 3100051

        ''' <summary>
        ''' �Ō�̏��F�҂́A��z��������t�^�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE052 = 3100052

        ''' <summary>
        ''' �������򂪐ݒ肳��Ă���ꍇ�́A��z��������t�^�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE053 = 3100053

        ''' <summary>
        ''' ���s���F���ݒ肳��Ă���ꍇ�́A��z��������t�^�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE054 = 3100054

        ''' <summary>
        ''' ��������ɏ������ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE055 = 3100055

        ''' <summary>
        ''' �������I�[�o�[���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE056 = 3100056

        ''' <summary>
        ''' ���l����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE057 = 3100057

        ''' <summary>
        ''' yyyy/mm/dd�`���œ��t����͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE058 = 3100058

        ''' <summary>
        ''' �K�{���ڂł��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE059 = 3100059

        ''' <summary>
        ''' �ŏI���F�ł̕��s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE060 = 3100060

        ''' <summary>
        ''' ���s���F�ł̓����E�����蓖�Ă邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE061 = 3100061

        ''' <summary>
        ''' �֘A�t���Ă��Ȃ����[�g�����݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE062 = 3100062

        ''' <summary>
        ''' �����͈̔͂��I�[�o�[���Ă܂��B{0}922,337,203,685,477.5807 �` -922,337,203,685,477.5808�͈̔͂œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE063 = 3100063

        ''' <summary>
        ''' �����͈̔͂��I�[�o�[���Ă܂��B{0}2,147,483,647 �` -2,147,483,648�͈̔͂œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE064 = 3100064

        ''' <summary>
        ''' �����̓��͂͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE065 = 3100065

        ''' <summary>
        ''' �g�D�Ɩ�E���N�Ď҂Ɠ������[�g�͎w��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE066 = 3100066

        ''' <summary>
        ''' �{�l�͋N�ă��[�g�Ɏw��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE067 = 3100067

        ''' <summary>
        ''' �������[�g�ł͍쐬�҃��[�g�ȊO�N�ă��[�g�Ɏw��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE068 = 3100068

        ''' <summary>
        ''' �{�l���܂߂����s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE069 = 3100069

        ''' <summary>
        ''' ����l���̕��s���F�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE070 = 3100070

        ''' <summary>
        ''' ��������������͕������F��̐\���敪�͐ݒ�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE071 = 3100071

        ''' <summary>
        ''' �֘A�t���Ă��Ȃ��������򂪑��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE072 = 3100072

        ''' <summary>
        ''' �Q�o�C�g�������܂܂�Ă��܂��B�Q�o�C�g�����͓��͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE073 = 3100073

        ''' <summary>
        ''' �����������Ă��܂��B�L��������11���܂łł��B
        ''' </summary>
        ''' <remarks></remarks>
        routeE074 = 3100074

        ''' <summary>
        ''' �J���}�̓��͂͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeE075 = 3100075

        ''' <summary>
        ''' ���͌`���Ɍ�肪����܂��B{0}-9999999999�̌`���œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeE076 = 3100076

        ''' <summary>
        ''' �J�e�S���͑I���ł��܂���B
        ''' </summary>
        ''' <remarks>
        ''' ���[�g/�t�H�[���������--�c���[�r���[���J�e�S���̃m�[�h���I������Ă����ꍇ
        ''' </remarks>
        MustNotCategorySelected = 3100077

        ''' <summary>
        ''' �ǉ����郋�[�g��I�����ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' ���[�g������ʂŊ����Ă�ׂ����[�g�f�[�^���c���[���I������Ă��Ȃ��ꍇ
        ''' </remarks>
        AddRouteUnSelected = 3100078

        ''' <summary>
        ''' �폜���郋�[�g��I�����ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' ���[�g������ʂō폜����ׂ����[�g�f�[�^�����X�g�r���[���I������Ă��Ȃ��ꍇ
        ''' </remarks>
        RemoveRouteUnSelected = 3100079

        ''' <summary>
        ''' ���łɓ������[�g���I������Ă��܂��B
        ''' </summary>
        ''' <remarks>
        ''' ���[�g������ʂőI�����[�g�f�[�^�����łɊ����f�[�^�Ƃ��đI������Ă���ꍇ
        ''' </remarks>
        SameRouteExist = 3100080

        ''' <summary>
        ''' �ǉ�����t�H�[����I�����ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[��������ʂŊ����Ă�ׂ��t�H�[���f�[�^���c���[���I������Ă��Ȃ��ꍇ
        ''' </remarks>
        AddFormUnSelected = 3100081

        ''' <summary>
        ''' �폜����t�H�[����I�����ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[��������ʂō폜����ׂ��t�H�[���f�[�^�����X�g�r���[���I������Ă��Ȃ��ꍇ
        ''' </remarks>
        RemoveFormUnSelected = 3100082

        ''' <summary>
        ''' ���łɓ����t�H�[�����I������Ă��܂��B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[��������ʂőI���t�H�[���f�[�^�����łɊ����f�[�^�Ƃ��đI������Ă���ꍇ
        ''' </remarks>
        SameFormExist = 3100083

        ''' <summary>
        ''' �r���[�̖����w�肵�ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �r���[�����e�i���X��ʐV�K�쐬���Ƀr���[���̂��w�肳��Ă��Ȃ��ꍇ
        ''' </remarks>
        SetNoViewName = 3100084

        ''' <summary>
        ''' �o�͂��鍀�ڂ��w�肵�ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �r���[�����e�i���X��ʂɂďo�͍��ڂ��P�����w�肳��Ă��Ȃ��ꍇ
        ''' </remarks>
        SetNoViewColumn = 3100085

        ''' <summary>
        ''' ���l����͂��ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' ���l���͍��ڂɕ����񂪍��݂���ꍇ
        ''' </remarks>
        UnNumeric = 3100086

        ''' <summary>
        ''' �̔Ԃ��s���ۂ̗L��������1�`10���ł��B
        ''' </summary>
        ''' <remarks>
        ''' �^�p�ݒ�--�̔ԍ��ړ��͕��L�������̐���
        ''' </remarks>
        VlDocNoFigOver10 = 3100087

        ''' <summary>
        ''' �̔ԍ��ڂɎw��\�ȍ��ڂ�20���ڂ܂łł��B
        ''' </summary>
        ''' <remarks>
        ''' �^�p�ݒ�--�̔ԍ��ړ��͍��ڂ�20���ڈȏ�w�肳��Ă���ꍇ
        ''' </remarks>
        DocColStructOver20 = 3100088

        ''' <summary>
        ''' �̔ԍ��ڂɘA�Ԃ�o�^���ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �^�p�ݒ�--�̔ԍ��ړ��͍��ڂɘA�Ԃ��w�肳��Ă��Ȃ��ꍇ
        ''' </remarks>
        DocColStructNoCounter = 3100089

        ''' <summary>
        ''' �̔ԍ��ڂ̍폜�͂ł��܂���B
        ''' </summary>
        ''' <remarks>
        ''' �^�p�ݒ�--�̔ԍ��ړ��͍��ڂ��폜���悤�Ƃ����ꍇ
        ''' </remarks>
        DocColStructCounterNotDelete = 3100090

        ''' <summary>
        ''' ���F���ۑ���͕K�{���͂ł��B{0}�ۑ�����w�肵�ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �^�p�ݒ�--���F���ۑ���̕K�{���̓`�F�b�N
        ''' </remarks>
        SetFullPassLblNmPubDoc = 3100091

        ''' <summary>
        ''' �۔F���ۑ���͕K�{���͂ł��B{0}�ۑ�����w�肵�ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �^�p�ݒ�--���F���ۑ���̕K�{���̓`�F�b�N
        ''' </remarks>
        SetFullPassLblNmNyDoc = 3100092

        ''' <summary>
        ''' �J�e�S��������͂��ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �J�e�S���쐬���--�J�e�S�����̂ɓ��͂������ꍇ
        ''' </remarks>
        UnInputCategoryName = 3100093

        ''' <summary>
        ''' �\����������͂��ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �J�e�S���쐬���--�\�������ɓ��͂������ꍇ
        ''' </remarks>
        UnInputCategoryDispNo = 3100094

        ''' <summary>
        ''' �J�e�S����I�����ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �J�e�S���쐬���--�\�������ɓ��͂������ꍇ
        ''' </remarks>
        CategoryUnSelcted = 3100095

        ''' <summary>
        ''' ���͉\�Ȕ͈͂𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks>
        ''' �J�e�S���쐬���--�\�����̎w�肪�͈͒l�Ŗ��������ꍇ
        ''' </remarks>
        OverRange = 3100096

        ''' <summary>
        ''' ���݂��̃t�H�[���͎g�p���ł��B�폜�ł��܂���B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[���폜���A���Y�t�H�[�������s���ł������ꍇ
        ''' </remarks>
        FormExecutingNotDelte = 3100097

        ''' <summary>
        ''' �t�H�[���̖�����͂��ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[���R�s�[��ʂɂăt�H�[�����̓��͂������ꍇ
        ''' </remarks>
        UnInputFormName = 3100098

        ''' <summary>
        ''' ���̃��[�g�͏��������ێ����܂��B{0}���̃t�H�[���ƕ��p������A�g�p�t�H�[����ύX���邱�Ƃ͏o���܂���B{0}�g�p�t�H�[���̕ύX������ꍇ�́w���[�g�C���x�{�^�����N���b�N���A{0}���̃��[�g����������̖�����Ԃɂ��ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' ���������ێ����郋�[�g�̎g�p�t�H�[����ύX���悤�Ƃ����ꍇ
        ''' </remarks>
        RuteHasBranch = 3100099

        ''' <summary>
        ''' �I�����ꂽ���[�g�͏�������ɑ��̃t�H�[���̍��ڂ��w�肳��Ă��܂��B{0}���̃t�H�[���Ŏg�p���邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks>
        ''' ���������ێ����郋�[�g�̎g�p�t�H�[����ύX���悤�Ƃ����ꍇ
        ''' </remarks>
        SelectedRuteHasBranch = 3100100

        ''' <summary>
        ''' �I�����ꂽ���[�g�͏�������ɂ��̃t�H�[���̍��ڂ��w�肳��Ă��܂��B{0}�폜���邱�Ƃ͂ł��܂���B{0}�폜����ꍇ�̓��C����ʂ́w���[�g�C���x�{�^�����N���b�N���A{0}���̃��[�g����������̖�����Ԃɂ��ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' ���������ێ�����g�p���[�g���폜���悤�Ƃ����ꍇ
        ''' </remarks>
        RemoveRuteHasBranch = 3100101

        ''' <summary>
        ''' �ؗ����Ԃ̓��͂͂P�c�Ɠ��ȏ���w�肵�ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �ؗ����Ԃ̉c�Ɠ��̓��͂� 0(�c�Ɠ�)�ȉ��ł���ꍇ
        ''' </remarks>
        OverRengeVlttl = 3100102

        ''' <summary>
        ''' Ridoc�A�g�ŕ����v���p�e�B�ݒ�̓o�^���s���ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �^�p�ݒ��ʂ́u�o�^�v�{�^���������A�����v���p�e�B�ݒ肪�o�^����Ă��邩�̃`�F�b�N��
        ''' </remarks>
        DocNotAddPropatyChk = 3100103

        ''' <summary>
        ''' �t�H�[�������J���ׁ̈A�폜�ł��܂���ł����B
        ''' </summary>
        ''' <remarks>
        ''' �^�p�ݒ��ʂŁA�t�H�[�����u�����J����v�ɐݒ肵�Ă���Ƃ��́A���[�g�t�H�[����ʂ���A�폜�`�F�b�N������
        ''' </remarks>
        FailedNotDelete = 3100104

        ''' <summary>
        ''' �I�����ꂽ�L���r�l�b�g�̃p�X���[�h��ݒ��ʂœo�^���ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �L���r�l�b�g�I�����p�X���[�h�����o�^�̎�
        ''' </remarks>
        CabPassNotRegistration = 3100105

        ''' <summary>
        ''' �ۑ�����w�肵�ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �t�H���_�ꗗTreeView�Ńm�[�h���I����Ԃ�OK�{�^���N���b�N��
        ''' </remarks>
        CabinetNotSelected = 3100106

        ''' <summary>
        ''' �C�ӕ�����͔��p�p���œ��͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        UnjustTxtFree = 3100107

        ''' <summary>
        ''' �A�g����v���p�e�B��I�����ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �����^�C�v�ݒ莞�ɑS�āh�ݒ肷��h�̏�Ԃŕ����v���p�e�B�����I���������́h�h�̎�
        ''' </remarks>
        DocPropNotSelected = 3100108

        ''' <summary>
        ''' �����ݑΏۃv���p�e�B���d�����Ă��܂��B
        ''' </summary>
        ''' <remarks>
        ''' �����^�C�v�ݒ莞�ɑS�āh�����݁h�ݒ肳��Ă��镶���v���p�e�B���d�����Ă鎞
        ''' </remarks>
        DocPropDuplication = 3100109

        ''' <summary>
        ''' Ridoc�v���p�e�B�u�������v�ւ́u�����ݐݒ�v�͕K�{�ł��B{0}�t�H�[���ɓ\�t���Ă��鍀�ڂ��ARidoc�v���p�e�B�u�������v�Ɂu�����ݐݒ�v���ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �����v���p�e�B�u�������v�ւ́u�����݁v�����ݒ�̎�
        ''' </remarks>
        DocNamePropNonSet = 3100110

        ''' <summary>
        ''' �I�����ꂽ�����v���p�e�B�͗\��v���p�e�B���ݒ肳��Ă��܂���B
        ''' </summary>
        ''' <remarks>
        ''' 2003/09/09 Add watanobe �\��v���p�e�B���ݒ肳��Ă��Ȃ������v���p�e�B��I��������
        ''' </remarks>
        DocPropNonSet = 3100111

        ''' <summary>
        ''' �����Ǘ��c�[���ɂĕ����^�C�v�̓o�^���s���ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' 2003/09/09 Add watanobe ���[�U�[�ݒ蕶���v���p�e�B�����݂��Ȃ���
        ''' </remarks>
        DocTypeNonSet = 3100112

        ''' <summary>
        ''' ����ݒ�ʒu���d�����Ă��܂��B
        ''' </summary>
        ''' <remarks>
        ''' 2003/09/09 Add watanobe ���[�U�[�ݒ蕶���v���p�e�B�����݂��Ȃ���
        ''' </remarks>
        PrintDataDuplication = 3100113

        ''' <summary>
        ''' �񓚊�������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ReplyLimit = 3100114

        ''' <summary>
        ''' �񓚊����̓��͂�1�c�Ɠ��ȏ���w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        ReplyLimitOutOfRange = 3100115

        ''' <summary>
        ''' �I�[�͋N�ă��[�g�Ɏw��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        RUN_E001 = 3100116

        ''' <summary>
        ''' �I�[���玟�̃��[�g�w�肷�鎖�͏o���܂���
        ''' </summary>
        ''' <remarks></remarks>
        RUN_E010 = 3100117

        ''' <summary>
        ''' ��������ȊO����I�[�����̃��[�g�Ɏw�肷�鎖�͏o���܂���
        ''' </summary>
        ''' <remarks></remarks>
        RUN_E011 = 3100118

        ''' <summary>
        ''' ���Ɋ֘A�t������Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        RUN_E020 = 3100119

        ''' <summary>
        ''' �����ȏ������ݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        RUN_E110 = 3100120

        ''' <summary>
        ''' �����A�g�D���Ғ��ł��B���΂炭�o������A�ēx���s���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3100121

    End Enum

#End Region

#Region " VFAX "

    ''' <summary>
    ''' VFAX �v���W�F�N�g�̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFAX]

        ''' <summary>
        ''' �e���v���[�g�̂��ߌ�ō폜���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 3110000

    End Enum

#End Region

#Region " VALP "

    ''' <summary>
    ''' VALP �v���W�F�N�g�̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VALP]

        ''' <summary>
        ''' �m���M�����[���A�h���X�n���m����̑��M�ҁn�ɐݒ肳��Ă���ꍇ�A�m���M�����[���A�h���X�n�͓��͕K�{���ڂł��B
        ''' </summary>
        ''' <remarks></remarks>
        Msg0001 = 3120001

        ''' <summary>
        ''' �m���M�����[���A�h���X�n�̌`��������������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        Msg0002 = 3120002

        ''' <summary>
        ''' ���p�҂̕ҏW�������Ȃ��ꍇ�A�m�����n�͓��͕K�{���ڂł��B
        ''' </summary>
        ''' <remarks></remarks>
        Msg0003 = 3120003

        ''' <summary>
        ''' ���p�҂̕ҏW�������Ȃ��ꍇ�A�m�{���n�͓��͕K�{���ڂł��B
        ''' </summary>
        ''' <remarks></remarks>
        Msg0004 = 3120004

    End Enum

#End Region

#Region " RFGC "

    ''' <summary>
    ''' �r���[�G�[�W�F���g�̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFGC]

        ''' <summary>
        ''' �r���[�̉^�p�ݒ�ňꊇ���[�����M�̏ڍאݒ肪�s���Ă��Ȃ����߁A���̉�ʂ��烁�[���𑗐M���邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotDetailSetting = 3130001

        ''' <summary>
        ''' ���[���̌����ɕ����̗\����ݒ肷�邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MultiReserveWork = 3130002

        ''' <summary>
        ''' ��������͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotInputMailSubject = 3130003

        ''' <summary>
        ''' �{������͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotInputMailBody = 3130004

    End Enum

#End Region

#Region " ACAB "

    ''' <summary>
    ''' R@bitFlow TextConverter �̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [ACAB]

        ''' <summary>
        ''' �ڑ�����T�[�o�[��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotServerSelected = 3140001

        ''' <summary>
        ''' �ݒ肷��b�r�u�t�B�[���h��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoselectCsvField = 3140002

        ''' <summary>
        ''' ���p�X�y�[�X�݂̂̓��͂͏o���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        SpaceOnly = 3140003

        ''' <summary>
        ''' �b�r�u�t�@�C���𐳂����Ǎ��߂܂���B
        ''' ���ڋ�؂蕶���E�s��؂蕶���E�e�L�X�g�C���q���m�F�����������B
        ''' </summary>
        ''' <remarks></remarks>
        ReadCsvFieldError = 3140004

        ''' <summary>
        ''' ���������l����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        chkIntegerError = 3140005

        ''' <summary>
        ''' �t�H�[����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectedForm = 3140006

        ''' <summary>
        ''' �t�H�[���`���u���[�N�t���[�v�ɂ͈ڍs�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoTransForm = 3140007

        ''' <summary>
        ''' �I�����ꂽ�t�H�[���ɂ͈ڍs�ł���t�B�[���h������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        SelectFormNoData = 3140008

        ''' <summary>
        ''' �ڍs����ݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectTrans = 3140009

        ''' <summary>
        ''' �L�[���P�I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotSelectedKey = 3140010

        ''' <summary>
        ''' �L�[�𕡐��I�����邱�Ƃ͏o���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        KeySelectedOnly = 3140011

        ''' <summary>
        ''' �I�������L�[�͈ڍs���鍀�ڂɊ܂߂�K�v������܂��B
        ''' </summary>
        ''' <remarks></remarks>
        AbsoluteSelectedKey = 3140012

        ''' <summary>
        ''' ���O�o�͍��ڂƂ��Đݒ�ł���̂͂R�t�B�[���h�܂łł��B
        ''' </summary>
        ''' <remarks></remarks>
        NotesKeyOverCount = 3140013

        ''' <summary>
        ''' ������I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectGroup = 3140014

        ''' <summary>
        ''' �쐬�҂�I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectCreater = 3140015

        ''' <summary>
        ''' �������l����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        chkStringError = 3140016

        ''' <summary>
        ''' �ő啶�����𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        chkFigureError = 3140017

        ''' <summary>
        ''' �L���Ȕ͈͂𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        chkRangeError = 3140018

        ''' <summary>
        ''' ���������t����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        chkDateError = 3140019

        ''' <summary>
        ''' �ݒ肳�ꂽ���t�̃t�H�[�}�b�g�ɕϊ��o���܂���B
        ''' �ݒ�l���m�F�����͂������ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateFormatError = 3140020

        ''' <summary>
        ''' �L�����t�𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateError = 3140021

        ''' <summary>
        ''' �I�������t�H�[����`�t�@�C���̈ڍs���̃f�[�^��ʂ�����������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MismatchedFile = 3140022

        ''' <summary>
        ''' ���O�C�����Ă���T�[�o�ƈقȂ�T�[�o�ւ̈ڍs�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoEqualTransServer = 3140023

        ''' <summary>
        ''' ���O�C�����Ă���T�[�o�ւ̃R�s�[�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        EqualTransServerError = 3140024

        ''' <summary>
        ''' {0}�́A{1}�ɂ͈ڍs�o���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonSetSubject = 3140025

        ''' <summary>
        ''' {0}�𕡐��t�B�[���h�Ɉڍs���邱�Ƃ͗��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        OneSelectNotesDocID = 3140026

        ''' <summary>
        ''' {0}, {1}�ȊO��
        ''' �ڍs���鍀�ڂ��Œ�P�ȏ�I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        TransFieldCountError = 3140027

        ''' <summary>
        ''' �ۑ��ł����`�t�@�C���̊g���q��.{0}�݂̂ł��B
        ''' </summary>
        ''' <remarks></remarks>
        NoXMLFileType = 3140028

        ''' <summary>
        ''' �R���g���[���}�X�^��������܂���B
        ''' �A�g�I�v�V�����̊��ݒ�^�u�ňڍs��T�[�o�[���w�肵�Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundEnvironmentSetting = 3140029

        ''' <summary>
        ''' �ڑ���̃T�[�o�[���ݒ肳��Ă��܂���B
        ''' ���ݒ�E�B�U�[�h��菉���ݒ���s���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        ServerWasNotSet = 3140030

        ''' <summary>
        ''' R@bitFlow �T�[�o�[����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        InputeRabitFlowServer = 3140031

        ''' <summary>
        ''' �������鎁������͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotSearchName = 3140032

    End Enum

#End Region

#Region " VRTC "

    ''' <summary>
    ''' R@bitFlow TextConverter �̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRTC]

        ''' <summary>
        ''' ���O�̕ۑ������͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        InputLogDir = 3150001

        ''' <summary>
        ''' ���O�̕ۑ��悪���݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundLogDir = 3150002

        ''' <summary>
        ''' ��ƃT�[�o�[����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        SelectWorkServer = 3150003

        ''' <summary>
        ''' ���[�U�[�h�c����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        InputLoginId = 3150004

        ''' <summary>
        ''' �p�X���[�h����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        InputPassword = 3150005

        ''' <summary>
        ''' �A�[�J�C�u�t�H���_����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        InputArchiveDir = 3150006

        ''' <summary>
        ''' �A�[�J�C�u�t�H���_��������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundArchiveDir = 3150007

        ''' <summary>
        ''' �f�[�^�t�@�C���̕ۑ������͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        InputDataDir = 3150008

        ''' <summary>
        ''' �g�����U�N�V�������O�t�@�C���̕ۑ������͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        InputTransactionLogDir = 3150009

        ''' <summary>
        ''' �C���X�^���X������͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        InputNamedInstance = 3150010

        ''' <summary>
        ''' �f�[�^�t�@�C���̕ۑ��悪������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundDataDir = 3150011

        ''' <summary>
        ''' �g�����U�N�V�������O�t�@�C���̕ۑ��悪������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundTransactionLogDir = 3150012

        ''' <summary>
        ''' SQL Server �ɐڑ��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        LocalServerConnectFailed = 3150013

    End Enum

#End Region

#Region " VRAC "

    ''' <summary>
    ''' R@bitFlow AccountConverter �̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRAC]

        ''' <summary>
        ''' CSV �ڍאݒ��ʂŁA�I���܂��͓��͂��� CSV �t�@�C�������݂��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0001 = 3160001

        ''' <summary>
        ''' CSV �ڍאݒ��ʂŁA�d�������t�@�C����ǉ����悤�Ƃ����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0002 = 3160002

        ''' <summary>
        ''' CSV �ڍאݒ��ʂŁA�ǉ��\�Ȍ����𒴂��ĘA�g�t�@�C����ǉ����悤�Ƃ����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0003 = 3160003

        ''' <summary>
        ''' CSV �t�@�C������������ʂŁA�d�������t�@�C����ǉ����悤�Ƃ����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0004 = 3160004

        ''' <summary>
        ''' CSV �t�@�C������������ʂŁA�I�������t�@�C�����e�t�@�C���̎q�t�@�C���ɐݒ肳��Ă���ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0005 = 3160005

        ''' <summary>
        ''' CSV �t�@�C������������ʂŁA�I�������q�t�@�C���̃t�B�[���h���e�t�@�C���̕ʂ̃t�B�[���h�Ɗ��Ɍ������Ă���ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0006 = 3160006

        ''' <summary>
        ''' �A�g�K�{���ڂɃt�B�[���h���ݒ肳��Ă��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0007 = 3160007

        ''' <summary>
        ''' CSV �t�B�[���h����������ʂŁA�����������ݒ肳��Ă��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0008 = 3160008

        ''' <summary>
        ''' CSV �ڍאݒ��ʂŁA�֘A�t������t�B�[���h�����t�@�C�����A���ɐݒ�ς݃t�B�[���h�̃t�@�C���ƌ������Ă��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0009 = 3160009

        ''' <summary>
        ''' CSV �t�@�C������������ʂŁA�I�������q�t�@�C�����e�t�@�C���̃t�B�[���h�ƘA�g���ڂɊ֘A�t�����Ă���ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0010 = 3160010

        ''' <summary>
        ''' ��������o�b�N�A�b�v���I������Ă��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0011 = 3160011

        ''' <summary>
        ''' ���O�C����ʂŃ��[�U�[ ID �����͂���Ă��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0012 = 3160012

        ''' <summary>
        ''' ���O�C����ʂŃp�X���[�h�����͂���Ă��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0013 = 3160013

        ''' <summary>
        ''' ��ƃt�H���_�����͂���Ă��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0014 = 3160014

        ''' <summary>
        ''' ���͂��ꂽ��ƃt�H���_�����݂��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0015 = 3160015

        ''' <summary>
        ''' �o�^���ɘA�g�t�@�C���� 1 �����ǉ�����Ă��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0016 = 3160016

        ''' <summary>
        ''' �ړ��t�@�C���̕ۊǊ��Ԃ��͈͂𒴂��Ă���ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0017 = 3160017

    End Enum

#End Region

#Region " MRAC "

    ''' <summary>
    ''' R@bitFlow AccountConverter �̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MRAC]

        ''' <summary>
        ''' �A�g�t�@�C���̃��R�[�h�̎�荞�݂Ɏ��s�����ꍇ�̃��b�Z�[�W
        ''' </summary>
        Msg0001 = 3170001

        ''' <summary>
        ''' �ꎞ�e�[�u���ւ̃��R�[�h�o�^�Ɏ��s�����ꍇ�̃��b�Z�[�W
        ''' </summary>
        Msg0002 = 3170002

        ''' <summary>
        ''' CSV �t�@�C����������Ȃ��ꍇ�̃��b�Z�[�W
        ''' </summary>
        Msg0003 = 3170003

        ''' <summary>
        ''' �C�ӂ̃��R�[�h���}�[�W�Ɏ��s�����ꍇ�̃��b�Z�[�W
        ''' </summary>
        Msg0004 = 3170004

        ''' <summary>
        ''' CSV �t�@�C������ǂݍ��񂾑g�D�̗L���J�n���t���A��ʑg�D�̗L���J�n���t��菬�����Ƃ��̌x�����b�Z�[�W
        ''' </summary>
        Msg0005 = 3170005

        ''' <summary>
        ''' CSV �t�@�C������ǂݍ��񂾑g�D�̗L���������t���A��ʑg�D�̗L���������t���傫���Ƃ��̌x�����b�Z�[�W
        ''' </summary>
        Msg0006 = 3170006

        ''' <summary>
        ''' ��������g�D���O���[�v�̏ꍇ�ɁA��E���i�O���[�v�����o�j�ɕύX����Ƃ��̃��b�Z�[�W
        ''' </summary>
        Msg0007 = 3170007

    End Enum

#End Region

#Region " VANC "

    ''' <summary>
    ''' R@bitFlow NotesConveter �̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VANC]

        ''' <summary>
        '''�I�����ꂽnsf�t�@�C���ɂ�{0}�ڍs�ł���t�H�[��������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        SelectNsfNoForm = 3180001

        ''' <summary>
        '''�I�����ꂽ�t�H�[���ɂ�{0}�ڍs�ł���t�B�[���h������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        SelectFormNoData = 3180002

        ''' <summary>
        '''�I�����ꂽnsf�t�@�C���ɂ�{0}�ڍs�ł���f�[�^������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        SelectNsfNoData = 3180003

        ''' <summary>
        '''�ڑ�����T�[�o�[��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NotServerSelected = 3180004

        ''' <summary>
        '''�p�X���[�h������������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotInputPassword = 3180005

        ''' <summary>
        '''���[�^�X�m�[�c�p�X���[�h���m�F�ł��܂���B�T�[�o�[���g�p�ł��Ȃ��\��������܂��B
        ''' </summary>
        ''' <remarks></remarks>
        NotConnectederver = 3180006

        ''' <summary>
        '''�ۑ��ł����`�t�@�C���̊g���q��.{0}�݂̂ł��B
        ''' </summary>
        ''' <remarks></remarks>
        _NoXMLFileType = 3180007

        ''' <summary>
        '''��`�t�@�C�����w�肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectedFilePath = 3180008

        ''' <summary>
        '''�m�[�c�c�a��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectedNotesDB = 3180009

        ''' <summary>
        '''�t�H�[����I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectedForm = 3180010

        ''' <summary>
        '''���O�o�͍��ڂƂ��Đݒ�ł���̂�{0}�R�t�B�[���h�܂łł��B
        ''' </summary>
        ''' <remarks></remarks>
        NotesKeyOverCount = 3180011

        ''' <summary>
        '''�P�t�B�[���h�ȏ��ݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectMappingInfo = 3180012

        ''' <summary>
        '''�ڍs���鍀�ڂ��Œ�P�ȏ�I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        TransFieldError = 3180013

        ''' <summary>
        '''�ڍs����ݒ肵�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectTrans = 3180014

        ''' <summary>
        '''�ݒ肷��m�[�c�t�B�[���h��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectNotesField = 3180015

        ''' <summary>
        '''�ݒ肷��b�r�u�t�B�[���h��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoselectCsvField = 3180016

        ''' <summary>
        '''�b�r�u�t�@�C���𐳂����Ǎ��߂܂���B{0}���ڋ�؂蕶���E�s��؂蕶���E�e�L�X�g�C���q���m�F�����������B
        ''' </summary>
        ''' <remarks></remarks>
        ReadCsvFieldError = 3180017

        ''' <summary>
        '''������I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectGroup = 3180018

        ''' <summary>
        '''�쐬�҂�I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectCreater = 3180019

        ''' <summary>
        '''���p�X�y�[�X�݂̂̓��͂͏o���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        SpaceOnly = 3180020

        ''' <summary>
        '''�������l����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        chkStringError = 3180021

        ''' <summary>
        '''�ő啶�����𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        chkFigureError = 3180022

        ''' <summary>
        '''�����l�͔��p�����̂ݐݒ�\�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        chkIntegerError = 3180023

        ''' <summary>
        '''�L���Ȕ͈͂𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        chkRangeError = 3180024

        ''' <summary>
        '''���������t����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        chkDateError = 3180025

        ''' <summary>
        '''�ݒ肳�ꂽ���t�̃t�H�[�}�b�g�ɕϊ��o���܂���B{0}�ݒ�l���m�F�����͂������ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateFormatError = 3180026

        ''' <summary>
        '''�L�����t�𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateError = 3180027

        ''' <summary>
        '''���ڋ�؂蕶���ƍs��؂蕶���ɓ�����؂蕶�����w�肷�邱�Ƃ͏o���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        SameSeparatorError = 3180028

        ''' <summary>
        '''�L�[���P�I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotSelectedKey = 3180029

        ''' <summary>
        '''�L�[�𕡐��I�����邱�Ƃ͏o���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        KeySelectedOnly = 3180030

        ''' <summary>
        '''�I�������L�[�͈ڍs���鍀�ڂɊ܂߂�K�v������܂��B
        ''' </summary>
        ''' <remarks></remarks>
        AbsoluteSelectedKey = 3180031

        ''' <summary>
        '''�I�������t�H�[����`�t�@�C���̈ڍs���̃f�[�^��ʂ�����������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MismatchedFile = 3180032

        ''' <summary>
        '''���O�C�����Ă���T�[�o�ƈقȂ�T�[�o�ւ̈ڍs�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoEqualTransServer = 3180033

        ''' <summary>
        '''���O�C�����Ă���T�[�o�ւ̃R�s�[�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        EqualTransServerError = 3180034

        ''' <summary>
        '''�t�H�[���`���u���[�N�t���[�v�ɂ͈ڍs�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoTransForm = 3180035

        ''' <summary>
        '''�ۑ��ł����`�t�@�C���̊g���q��.{0}�݂̂ł��B
        ''' </summary>
        ''' <remarks></remarks>
        NoXMLFileType = 3180036

        ''' <summary>
        '''{0} �A{1}�ȊO��{2}�ڍs���鍀�ڂ��Œ�P�ȏ�I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        TransFieldCountError = 3180037

        ''' <summary>
        '''{0}�́A{1}�ɂ͈ڍs�o���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonSetSubject = 3180038

        ''' <summary>
        '''{0}�͑I�����ꂽ�t�B�[���h�ɂ͈ڍs�o���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectFileldKey = 3180039

        ''' <summary>
        '''{0}�͕K�{�ݒ�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectNotesDocID = 3180040

        ''' <summary>
        '''{0}�𕡐��t�B�[���h�Ɉڍs���邱�Ƃ͗��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        OneSelectNotesDocID = 3180041

        ''' <summary>
        '''���[�U�[ID����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        UserIdEmpty = 3180042

        ''' <summary>
        '''�p�X���[�h����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        PasswordEmpty = 3180043

        ''' <summary>
        ''' �������鎁������͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        NotSearchName = 3180044

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 3180045

        ''' <summary>
        ''' �\�����ʗ�O�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        UnknowException = 3180046

        ''' <summary>
        ''' �t�H�[���ɕR�Â�UD�e�[�u�����t�H�[����1��1�ł͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        OneToOneMapping4UDException = 3180047

        ''' <summary>
        ''' ����}�X�^�[�����j�[�N�ł͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonuniqueRestrictionException = 3180048

        ''' <summary>
        ''' ���O�̏o�͐悪�s���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        UnknownLogDevice = 3180049

        ''' <summary>
        ''' ����̎��s��ʂ��s���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        UnknownActivateTypeException = 3180050

        ''' <summary>
        ''' �t�B�[���hID���Z�b�g����Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        UnSetIDFieldException = 3180051

        ''' <summary>
        ''' �t�B�[���hID�����j�[�N�ł͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonuniqueIDFLDException = 3180052

        ''' <summary>
        ''' �X���b�h���I���ł��܂���
        ''' </summary>
        ''' <remarks></remarks>
        ThreadIsAliveException = 3180053

        ''' <summary>
        ''' {0}�����݂��܂���
        ''' </summary>
        ''' <remarks></remarks>
        XMLNotFoundException = 3180054

        ''' <summary>
        ''' ��`�t�@�C�����ύX����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ChildXMLChangedException = 3180055

        ''' <summary>
        ''' ���X�t�H�[���܂��̓T�u�t�H�[�������݂��邽�ߍ폜�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ExistenceOfResOrSubException = 3180056

        ''' <summary>
        ''' �T�u�t�H�[�������݂��邽�ߍ폜�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ExistenceOfSubException = 3180057

        ''' <summary>
        ''' �C���X�^���X�̍Đ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ReviveFailedException = 3180058

        ''' <summary>
        ''' ��ʂ̃L�����Z�����I������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        CanceledFormLoadException = 3180059

        ''' <summary>
        ''' ���������Ɏ��s�B
        ''' </summary>
        ''' <remarks></remarks>
        CheckSubject = 3180060

        ''' <summary>
        ''' �C���[�W�^�O�쐬�Ɏ��s�B
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundTargetLinkException = 3180061

        ''' <summary>
        ''' �I�����ꂽ�t�H�[���ɂ̓f�[�^���ꌏ������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NoDataInNsf = 3180062

        ''' <summary>
        ''' ���O�C���L�����Z���B
        ''' </summary>
        ''' <remarks></remarks>
        NotesLoginCancel = 3180063

        ''' <summary>
        ''' �w�肳�ꂽTransInfo������������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        SetTransInfoError = 3180064

        ''' <summary>
        ''' ����}�X�^�Ƀf�[�^�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        SeiyakuMasterNotFound = 3180065

        ''' <summary>
        ''' ����}�X�^�[�̍X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SeiyakuMasterUpdateErr = 3180066

        ''' <summary>
        ''' ���l�ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        chkNumericError = 3180067

        ''' <summary>
        ''' ����/���z�ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        chkMoneyError = 3180068

        ''' <summary>
        ''' ���t�ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ChangeDateError = 3180069

        ''' <summary>
        ''' ���O�C�����Ă���T�[�o�ƈقȂ�T�[�o�ւ̈ڍs�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotIdentificationLoginServerException = 3180070

        ''' <summary>
        ''' �ڍs��ʂ���v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FromDBTypeIdentificationException = 3180071

        ''' <summary>
        ''' �ڍs���T�[�o����v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FromMachineNameIdentificationException = 3180072

        ''' <summary>
        ''' �ڍs���t�@�C��������v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FromFileNameIdentificationException = 3180073

        ''' <summary>
        ''' �ڍs���t�@�C���p�X����v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FromFilePathIdentificationException = 3180074

        ''' <summary>
        ''' �ڍs��T�[�o�[����v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ToServerIdentificationException = 3180075

        ''' <summary>
        ''' �쐬�҂���v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CreateSysBlgIdentificationException = 3180076

        ''' <summary>
        ''' �쐬�҂���v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CreateUserIdentificationException = 3180077

        ''' <summary>
        ''' �쐬�҂���v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CreateUserNMIdentificationException = 3180078

        ''' <summary>
        ''' �ڍs��t�H�[������v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MainToFormIDIdentificationException = 3180079

        ''' <summary>
        ''' �ڍs��t�H�[������v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ResToFormIDIdentificationException = 3180080

        ''' <summary>
        ''' ���C���t�H�[���̈ڍs�悪���݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundMainformException = 3180081

        ''' <summary>
        ''' ���C���t�H�[���ɕR�Â��ꂽ�T�u�t�H�[���ł͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotSelectedMainsSubFormException = 3180082

        ''' <summary>
        ''' ���C���t�H�[���ɕR�Â��ꂽ���X�t�H�[���ł͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotSelectedMainsResFormException = 3180083

        ''' <summary>
        ''' ���C���t�H�[�����ɖ{�T�u�t�H�[�����Ăяo��GUI���ڂ����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        UnUniqSbuGuip = 3180084

        ''' <summary>
        ''' �I�����ꂽ�T�u�t�H�[���͊��ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        AlreadySetFormException = 3180085

        ''' <summary>
        ''' �ڍs�悪���X�t�H�[���܂��̓T�u�t�H�[���ɂȂ��Ă����`�t�@�C���͑I���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MainFrmIsNotBBSAndWFBBSException = 3180086

        ''' <summary>
        ''' Notes �f�[�^�x�[�X��I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        PleaseSelectNotesDb = 3180087

        ''' <summary>
        ''' �Ǎ��݉\�Ȓ�`�t�@�C���ł͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        AdmFileError = 3180088

        ''' <summary>
        ''' �ۑ�����f�[�^�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DataForSaveEmpty = 3180089

        ''' <summary>
        ''' �T�[�o�[�ɐڑ��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ConnToServerError = 3180090

        ''' <summary>
        ''' CSV�t�@�C���̃��C�A�E�g������������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CSVFileError = 3180091

        ''' <summary>
        ''' �I�����ꂽ�t�@�C���͊��ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ExistedFile = 3180092

        ''' <summary>
        '''�o�^����f�[�^�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ''' 
        EmptyData = 3180093

        ''' <summary>
        '''�^�X�N��I�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        ''' 
        PlsSelectTask = 3180094

        ''' <summary>
        '''�ꎞ�f�[�^�����݂��Ȃ����߁A�I���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectEmpytTempData = 3180095

        ''' <summary>
        '''�ꎞ�f�[�^�����݂��Ȃ����߁A�A�b�v���[�h�ł��܂���B 
        ''' </summary>
        ''' <remarks></remarks>
        NothingTempData = 3180096

        ''' <summary>
        '''���F�҂�I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectAccepter = 3180097
    End Enum

#End Region

#Region " VAGP "

    ''' <summary>
    ''' R@bitFlow NotesConveter �̌x�����b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VAGP]

        ''' <summary>
        '''�w�肳�ꂽ���|�[�g���͒������ł��B
        ''' </summary>
        ''' <remarks></remarks>
        Msg0001 = 3190001

        ''' <summary>
        '''���[������͂��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        Msg0002 = 3190002

        ''' <summary>
        '''�w�肳�ꂽ���[���͊��ɑ��݂��܂��̂ŁA�w�肵�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        Msg0003 = 3190003

        ''' <summary>
        '''���ɂ��̏����͐ݒ肳��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        Msg0004 = 3190004
    End Enum

#End Region
End Namespace
