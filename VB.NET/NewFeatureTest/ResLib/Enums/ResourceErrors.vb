Option Compare Binary
Option Explicit On
Option Strict On

Imports System

'
' �G���[
'
Namespace [Error]
#Region " Common "
    ''' <summary>
    ''' �A�v���P�[�V�������ʂ̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [Common]

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        UnKnownSystemError = 1010001

        ''' <summary>
        ''' �f�[�^�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DataEntryFailed = 1010002

        ''' <summary>
        ''' �f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DataDeleteFailed = 1010003
        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        OtherError = 1010004

    End Enum
#End Region

#Region " RFLW "

    ''' <summary>
    ''' R@bitFlow �N���C�A���g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFLW]

        ''' <summary>
        '''Ridoc�G���[�ł��B�Ǘ��҂ɖ₢���킹�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RidocError = 1020001

        ''' <summary>
        '''�\��������Ridoc�ɂĎg�p���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        RidocDocumentLockedError = 1020002

        ''' <summary>
        '''�Ӎ쐬�Ɏ��s���܂����B{0}��������蒼���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MakeCopyStampSubmitError = 1020003

        ''' <summary>
        '''�Ӎ쐬�Ɏ��s���܂����B{0}��������蒼���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        MakeCopyStampDenyError = 1020004

        ''' <summary>
        '''�����̂`�b�k�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SetACLError = 1020005

        ''' <summary>
        '''�V�X�e���G���[�ł��B�Ǘ��҂ɖ₢���킹�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        SystemError = 1020006

        ''' <summary>
        '''�������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InitFailed = 1020007

        ''' <summary>
        '''{0}�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MakeFailed = 1020008

        ''' <summary>
        '''{0}�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AcceptFailed = 1020009

        ''' <summary>
        '''{0}�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SubmitFailed = 1020010

        ''' <summary>
        '''{0}�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DenyFailed = 1020011

        ''' <summary>
        '''{0}�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        RemandFailed = 1020012

        ''' <summary>
        '''�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ProcessFailed = 1020013

        ''' <summary>
        '''���[�����M�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SendMailFailed = 1020014

        ''' <summary>
        '''���J�҂̒ǉ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AddPublicationFailed = 1020015

        ''' <summary>
        '''���J�҂̍폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DelPublicationFailed = 1020016

        ''' <summary>
        '''�Q�Ǝ҂̒ǉ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AddReferenceFailed = 1020017

        ''' <summary>
        '''�Q�Ǝ҂̍폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DelReferenceFailed = 1020018

        ''' <summary>
        '''����{0}�҂�������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NextNUserNotFind = 1020019

        ''' <summary>
        '''�O��{0}�҂�������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        PrevNUserNotFind = 1020020

        ''' <summary>
        '''{0}��������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MakeNUserNotFind = 1020021

        ''' <summary>
        '''�O�̃y�[�W�ɖ߂�܂���B
        ''' </summary>
        ''' <remarks></remarks>
        PageBackToFailed = 1020022

        ''' <summary>
        '''���̃y�[�W�ɐi�߂܂���B
        ''' </summary>
        ''' <remarks></remarks>
        PageGoToFailed = 1020023

        ''' <summary>
        '''�t�H�[���̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetFormFailed = 1020024

        ''' <summary>
        '''�r���[�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetViewFailed = 1020025

        ''' <summary>
        '''�����̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetDocumentFailed = 1020026

        ''' <summary>
        '''�ꊇ{0}�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AllAcceptFalied = 1020027

        ''' <summary>
        '''�b�r�u�t�@�C���̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        CreateCSVFailed = 1020028

        ''' <summary>
        '''���[�g�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        CreateRouteFailed = 1020029

        ''' <summary>
        '''���t�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetCalFailed = 1020030

        ''' <summary>
        '''�t�H�[���N�������Ɉُ킪�������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        CallFailed = 1020031

        ''' <summary>
        '''�r�����������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocReleaseUpdate = 1020032

        ''' <summary>
        '''�����C���˗������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocCutIntoErr = 1020033

        ''' <summary>
        '''�����C�����������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocCutIntoOnErr = 1020034

        ''' <summary>
        '''�\�������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocMakeErr = 1020035

        ''' <summary>
        '''�R�������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocAcceptErr = 1020036

        ''' <summary>
        '''���F�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocSubmitErr = 1020037

        ''' <summary>
        '''���߂������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocRemandErr = 1020038

        ''' <summary>
        '''�۔F�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocDenyErr = 1020039

        ''' <summary>
        '''�f�t�H���g�����ݒ�̏��������s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DefSysBlgUpdateErr = 1020040

        ''' <summary>
        '''�`�F�b�N�C�������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        CheckInProcessFailed = 1020041

        ''' <summary>
        '''�`�F�b�N�A�E�g�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        CheckOutProcessFailed = 1020042

        ''' <summary>
        '''{0}
        ''' </summary>
        ''' <remarks></remarks>
        OtherError = 1020043

        ''' <summary>
        ''' �Ј����̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        UserInfoGetException = 1020044

        ''' <summary>
        '''�t�H�[���ُ킪��������܂����B�Ǘ��҂ɖ₢���킹�Ă�������
        ''' </summary>
        ''' <remarks></remarks>
        NonBasePage = 1020045

        ''' <summary>
        '''�ꗗ�\���Ɉُ픭�����܂����B�Ǘ��҂ɖ₢���킹�Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        FailedDBGrid = 1020046

        ''' <summary>
        '''������Ȗڂ̐ݒ�Ɉُ픭�����܂����B�Ǘ��҂ɖ₢���킹�Ă�������
        ''' </summary>
        ''' <remarks></remarks>
        FailedIncent = 1020047

        ''' <summary>
        '''�o�^�f�[�^�擾���s���܂����B�Ǘ��҂ɖ₢���킹�Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetProperty = 1020048

        ''' <summary>
        '''����{0}�ɐ��l����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        illegalDataInput = 1020049

        ''' <summary>
        '''�v�Z���̐ݒ�Ɍ�肪����܂��B{1}����{0}�͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotFieldInExpress = 1020050

    End Enum

#End Region

#Region " NGUI "

    ''' <summary>
    ''' NGUI �v���W�F�N�g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [NGUI]

        ''' <summary>
        '''�t�H�[���N�����Ɉُ킪�������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FormInitFailed = 1030001

        ''' <summary>
        '''���ځu{0}�v�̃t�H�[���\�����Ɉُ킪�������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InitFailed = 1030002

        ''' <summary>
        '''���ځu{0}�v�̃f�[�^�擾���Ɉُ킪�������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        LoadFailed = 1030003

        ''' <summary>
        '''���ځu{0}�v�̃f�[�^�ۑ����Ɉُ킪�������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SaveFailed = 1030004

        ''' <summary>
        '''���ځu{0}�v�Ő���ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ChangeGregorianClFailed = 1030005

        ''' <summary>
        '''���ځu{0}�v�Řa��ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ChangeJapaneseEraFailed = 1030006

    End Enum

#End Region

#Region " VEGG "

    ''' <summary>
    ''' VEGG �v���W�F�N�g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VEGG]

        ''' <summary>
        ''' �f�[�^�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedAdd = 1040001

        ''' <summary>
        ''' �f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedDelete = 1040002

        ''' <summary>
        ''' �g�D���җ����̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetInnavationDate = 1040003

        ''' <summary>
        ''' �J�e�S���f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetCategory = 1040004


        ''' <summary>
        ''' �f�[�^�R�s�[�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedCopy = 1040005


        ''' <summary>
        ''' �^�p�ݒ�f�[�^�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledAddFormDetaile = 1040006

        ''' <summary>
        ''' �t�H�[���̏ڍ׃f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetFormHeader = 1040007


        ''' <summary>
        ''' ���[�g�̏ڍ׃f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetRouteHeader = 1040008


        ''' <summary>
        ''' �g�p�t�H�[���̃f�[�^�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledUpdateJoinForm = 1040009

        ''' <summary>
        ''' �g�p���[�g�̃f�[�^�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledUpdateJoinRoute = 1040010

        ''' <summary>
        ''' �r���[���f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetView = 1040011

        ''' <summary>
        ''' �̔ԍ��ڃf�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetDocumentNumber = 1040012

        ''' <summary>
        ''' �V�X�e���G���[�ł��B�\�����ʃG���[���������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SystemUnKnownError = 1040013


        ''' <summary>
        ''' �t�H�[�������J���ׁ̈A�폜�ł��܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedNotDelete = 1040014

        ''' <summary>
        ''' �����v���p�e�B���o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocPropEntryFailed = 1040015

        ''' <summary>
        ''' �����v���p�e�B���o�^�p�f�[�^�쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>

        DocPropEntryDataFailed = 1040016

        ''' <summary>
        ''' �����^�C�v�ꗗ�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetDocPropListFailed = 1040017

        ''' <summary>
        ''' �����v���p�e�B�A�g���擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetDataFailed = 1040018

        ''' <summary>
        ''' �t�H�[���f�[�^��擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetFormDataFailed = 1040019

        ''' <summary>
        ''' �L���r�l�b�g�ꗗ���擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetCabListFailed = 1040020

        ''' <summary>
        ''' �V�X�e���G���[�ł��B�Ǘ��҂ɖ₢���킹�ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        SystemError = 1040021

        ''' <summary>
        ''' �g�p�t�H�[���̊����f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetJoinForm = 1040022

        ''' <summary>
        ''' �g�p���[�g�̊����f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetJoinRoute = 1040023


        ''' <summary>
        ''' �g�p���[�g�E�t�H�[���̊����f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledDeleteJoinData = 1040024

        ''' <summary>
        ''' �g�p���[�g�E�t�H�[���̊����f�[�^�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledAddJoinData = 1040025

        ''' <summary>
        ''' �^�p�ݒ�f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetFormDetaile = 1040026

        ''' <summary>
        ''' ���|�[�g�G�f�B�^�̋N���Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ReportEditorAbonMessage = 1040027

        ''' <summary>
        ''' �Ǘ����[�̋N���Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ReportToolAbonMessage = 1040028


        ''' <summary>
        ''' �J�e�S����ǂݍ��ނ��Ƃ��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CategoryCanNotRead = 1040029

        ''' <summary>
        ''' �t�H�[����ǂݍ��ނ��Ƃ��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FormCanNotRead = 1040030

        ''' <summary>
        ''' �r���[��ǂݍ��ނ��Ƃ��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ViewCanNotRead = 1040031

        ''' <summary>
        ''' ������ǂݍ��ނ��Ƃ��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentCanNotRead = 1040032

        ''' <summary>
        ''' �����̍X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentModifyFailed = 1040033

        ''' <summary>
        ''' �����̍폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentDeleteFailed = 1040034

        ''' <summary>
        ''' Ridoc�̕����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        RidocFailed = 1040035

        ''' <summary>
        ''' �\�����ڂɑΏۈȊO�̃t�H�[���̍��ڂ��I������Ă��܂��B[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectErrorView = 1040036

        ''' <summary>
        ''' �O���[�v���ڂɑΏۈȊO�̃t�H�[���̍��ڂ��I������Ă��܂��B[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectErrorGroup = 1040037

        ''' <summary>
        ''' �������ڂɑΏۈȊO�̃t�H�[���̍��ڂ��I������Ă��܂��B[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectErrorCondition = 1040038

        ''' <summary>
        ''' �������ڂɑΏۈȊO�̃t�H�[���̍��ڂ��I������Ă��܂��B[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC030 = 1040039

        ''' <summary>
        ''' �\���������͂���Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC017 = 1040040

        ''' <summary>
        ''' �I�����ꂽ�\�����͊��ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeC018 = 1040041
        ''' <summary>
        ''' �t�@�C���̎�荞�ݒ��Ɉُ킪�������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FormConvertFailed = 1040042
    End Enum

#End Region

#Region " VFRM "

    ''' <summary>
    ''' VFRM �v���W�F�N�g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFRM]

        '''<summary>
        '''�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedSave = 1050001

        ''' <summary>
        '''�v���p�e�B�̐ݒ�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        PropertySetFailed = 1050002

        ''' <summary>
        '''�t�H�[���͌�����܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FailedOpen = 1050003

        ''' <summary>
        '''�V�X�e���G���[�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        SystemError = 1050004

        ''' <summary>
        '''�t�H�[�����̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FormDataNotRead = 1050005

        ''' <summary>
        '''{0}�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FormDataNotReadFor = 1050006

        ''' <summary>
        '''{0}
        ''' </summary>
        ''' <remarks></remarks>
        OtherError = 1050007

    End Enum

#End Region

#Region " VGUI "

    ''' <summary>
    ''' VGUI �v���W�F�N�g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks>6</remarks>
    Public Enum [VGUI]

        ''' <summary>
        '''�����v���p�e�B�̓Ǎ��݂Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ReadPropertyFailed = 1060001

        ''' <summary>
        '''�V�K�v���p�e�B���쐬�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NewInstanceNotMake = 1060002

        ''' <summary>
        '''�v���p�e�B�̓o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SyncFailed = 1060003

        ''' <summary>
        '''�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ErrorCatchVGUI0001 = 1060004

        ''' <summary>
        '''�\�����ʃG���[���������܂����B�Ǘ��҂ɂ��₢���킹�������B
        ''' </summary>
        ''' <remarks></remarks>
        SystemError = 1060005

        ''' <summary>
        '''���ڂ̐ݒ肪��肪����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ItemSetError = 1060006

    End Enum

#End Region

#Region " VJNJ "

    ''' <summary>
    ''' VJNJ �v���W�F�N�g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VJNJ]

        ''' <summary>
        ''' �A�v���P�[�V�����̌p�����s�\�ȗ�O���������܂����B
        ''' �ڂ����̓V�X�e���Ǘ��҂ɂ��₢���킹���������B
        ''' </summary>
        CommonMsg0000 = 1070001

        ''' <summary>
        ''' �����ݒ��ʂ̋N���Ɏ��s���܂����B
        ''' </summary>
        AffiliationMsg0001 = 1071001

        ''' <summary>
        ''' �g�D�E�O���[�v��\�����邱�Ƃ��ł��܂���B
        ''' </summary>
        AffiliationMsg0002 = 1071002

        ''' <summary>
        ''' ������\�����邱�Ƃ��ł��܂���B
        ''' </summary>
        AffiliationMsg0003 = 1071003

        ''' <summary>
        ''' �g�D�E�O���[�v�ʏ����ݒ��ʂ��J�����Ƃ��ł��܂���B
        ''' </summary>
        AffiliationMsg0004 = 1071004

        ''' <summary>
        ''' �l�ʏ����ݒ��ʂ��J�����Ƃ��ł��܂���B
        ''' </summary>
        AffiliationMsg0005 = 1071005

        ''' <summary>
        ''' �l�ꗗ��\�����邱�Ƃ��ł��܂���B
        ''' </summary>
        AffiliationMsg0006 = 1071006

        ''' <summary>
        ''' �l�̌����Ɏ��s���܂����B
        ''' </summary>
        AffiliationMsg0007 = 1071007

        ''' <summary>
        ''' �����ɒǉ��ł��܂���B
        ''' </summary>
        AffiliationMsg0008 = 1071008

        ''' <summary>
        ''' �������폜�ł��܂���B
        ''' </summary>
        AffiliationMsg0009 = 1071009

        ''' <summary>
        ''' ��������\���ł��܂���B
        ''' </summary>
        AffiliationMsg0010 = 1071010

        ''' <summary>
        ''' �����̓o�^�Ɏ��s���܂����B
        ''' </summary>
        AffiliationMsg0011 = 1071011

        ''' <summary>
        ''' ����o�^��ʂ̋N���Ɏ��s���܂����B
        ''' </summary>
        BranchMsg0001 = 1072001

        ''' <summary>
        ''' �����ǉ����邱�Ƃ��ł��܂���B
        ''' </summary>
        BranchMsg0002 = 1072002

        ''' <summary>
        ''' ������폜���邱�Ƃ��ł��܂���B
        ''' </summary>
        BranchMsg0003 = 1072003

        ''' <summary>
        ''' ����̓o�^�Ɏ��s���܂����B
        ''' </summary>
        BranchMsg0004 = 1072004

        ''' <summary>
        ''' �g�D�E�O���[�v�o�^��ʂ̋N���Ɏ��s���܂����B
        ''' </summary>
        GroupMsg0001 = 1073001

        ''' <summary>
        ''' �g�D�E�O���[�v��\�����邱�Ƃ��ł��܂���B
        ''' </summary>
        GroupMsg0002 = 1073002

        ''' <summary>
        ''' �I�������g�D�E�O���[�v�̏���\�����邱�Ƃ��ł��܂���B
        ''' </summary>
        GroupMsg0003 = 1073003

        ''' <summary>
        ''' �h���C������O���[�v���擾���邱�Ƃ��ł��܂���B
        ''' </summary>
        GroupMsg0004 = 1073004

        ''' <summary>
        ''' �g�D�E�O���[�v�̓o�^�Ɏ��s���܂����B
        ''' </summary>
        GroupMsg0005 = 1073005

        ''' <summary>
        ''' �g�D�̍폜�Ɏ��s���܂����B
        ''' </summary>
        GroupMsg0006 = 1073006

        ''' <summary>
        ''' �l�o�^��ʂ̋N���Ɏ��s���܂����B
        ''' </summary>
        PersonMsg0001 = 1074001

        ''' <summary>
        ''' �l�ꗗ��\�����邱�Ƃ��ł��܂���B
        ''' </summary>
        PersonMsg0002 = 1074002

        ''' <summary>
        ''' �l�o�^��ʂ̋N���Ɏ��s���܂����B
        ''' </summary>
        PersonMsg0003 = 1074003

        ''' <summary>
        ''' �l�̓o�^�Ɏ��s���܂����B
        ''' </summary>
        PersonMsg0004 = 1074004

        ''' <summary>
        ''' �l�̍폜�Ɏ��s���܂����B
        ''' </summary>
        PersonMsg0005 = 1074005

        ''' <summary>
        ''' ��E�o�^��ʂ̋N���Ɏ��s���܂����B
        ''' </summary>
        PositionMsg0001 = 1075001

        ''' <summary>
        ''' ��E��\�����邱�Ƃ��ł��܂���B
        ''' </summary>
        PositionMsg0002 = 1075002

        ''' <summary>
        ''' �I��������E�̏���\�����邱�Ƃ��ł��܂���B
        ''' </summary>
        PositionMsg0003 = 1075003

        ''' <summary>
        ''' ��E�̓o�^�Ɏ��s���܂����B
        ''' </summary>
        PositionMsg0004 = 1075004

        ''' <summary>
        ''' ��E�̍폜�Ɏ��s���܂����B
        ''' </summary>
        PositionMsg0005 = 1075005

        ''' <summary>
        ''' �㗝�Ґݒ��ʂ̋N���Ɏ��s���܂����B
        ''' </summary>
        ProxyMsg0001 = 1076001

        ''' <summary>
        ''' �g�D�E�O���[�v��\�����邱�Ƃ��ł��܂���B
        ''' </summary>
        ProxyMsg0002 = 1076002

        ''' <summary>
        ''' ������\�����邱�Ƃ��ł��܂���B
        ''' </summary>
        ProxyMsg0003 = 1076003

        ''' <summary>
        ''' �㗝�Ґݒ��ʂ��J�����Ƃ��ł��܂���B
        ''' </summary>
        ProxyMsg0004 = 1076004

        ''' <summary>
        ''' �����̌����Ɏ��s���܂����B
        ''' </summary>
        ProxyMsg0005 = 1076005

        ''' <summary>
        ''' �㗝�҂�ǉ����邱�Ƃ��ł��܂���B
        ''' </summary>
        ProxyMsg0006 = 1076006

        ''' <summary>
        ''' �㗝�҂��폜���邱�Ƃ��ł��܂���B
        ''' </summary>
        ProxyMsg0007 = 1076007

        ''' <summary>
        ''' �㗝�҂̓o�^�Ɏ��s���܂����B
        ''' </summary>
        ProxyMsg0008 = 1076008

        ''' <summary>
        ''' �㗝�ҏ���\�����邱�Ƃ��ł��܂���B
        ''' </summary>
        ProxyMsg0009 = 1076009

    End Enum

#End Region

#Region " VMNU "

    ''' <summary>
    ''' VMNU �v���W�F�N�g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VMNU]

        ''' <summary>
        ''' �f�[�^�x�[�X�̐ڑ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DbConnectFailure = 1080001

        ''' <summary>
        ''' �f�[�^�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AddFailure = 1080002

        ''' <summary>
        ''' �f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DelFailure = 1080003

        ''' <summary>
        ''' ���W�X�g���ɏ������ތ���������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        LackingAuthority = 1080004

        ''' <summary>
        ''' ���W�X�g����񂪊Ԉ���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        RegistryFailure = 1080005

        ''' <summary>
        ''' {0}�����W�X�g�����ɕs�����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        RegistryFailureAt = 1080006

    End Enum

#End Region

#Region " VRTE "

    ''' <summary>
    ''' VRTE �v���W�F�N�g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRTE]

        ''' <summary>
        ''' �g�D��񂪎擾���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC001 = 1090001

        ''' <summary>
        ''' �g�D��񂪎擾���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC002 = 1090002

        ''' <summary>
        ''' �Ј���񂪎擾���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC003 = 1090003

        ''' <summary>
        ''' �Ј���񂪎擾���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC004 = 1090004

        ''' <summary>
        ''' �P�̃��[�g�擾���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC005 = 1090005

        ''' <summary>
        ''' �P�̃��[�g�擾���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC006 = 1090006

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B�ēx�A�쐬���Ȃ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeC007 = 1090007

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B�ēx�A�쐬���Ȃ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeC008 = 1090008

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B�ēx�A�쐬���Ȃ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeC009 = 1090009

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B�ēx�A�쐬���Ȃ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeC010 = 1090010

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B�ēx�A�쐬���Ȃ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeC011 = 1090011

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B�ēx�A�쐬���Ȃ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeC012 = 1090012

        ''' <summary>
        ''' �o�^�����ŃG���[���������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        routeC013 = 1090013

        ''' <summary>
        ''' �X�V�����ŃG���[���������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        routeC014 = 1090014

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        routeEX00 = 1090015

    End Enum

#End Region

#Region " VRUN "

    ''' <summary>
    ''' VRUN �v���W�F�N�g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRUN]

        ''' <summary>
        ''' �g�D��񂪎擾���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC001 = 1100001

        ''' <summary>
        ''' �g�D��񂪎擾���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC002 = 1100002

        ''' <summary>
        ''' �Ј���񂪎擾���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC003 = 1100003

        ''' <summary>
        ''' �Ј���񂪎擾���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC004 = 1100004

        ''' <summary>
        ''' �P�̃��[�g�擾���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC005 = 1100005

        ''' <summary>
        ''' �P�̃��[�g�擾���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC006 = 1100006

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B�ēx�A�쐬���Ȃ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeC007 = 1100007

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B�ēx�A�쐬���Ȃ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeC008 = 1100008

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B�ēx�A�쐬���Ȃ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeC009 = 1100009

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B�ēx�A�쐬���Ȃ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeC010 = 1100010

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B�ēx�A�쐬���Ȃ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeC011 = 1100011

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B�ēx�A�쐬���Ȃ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeC012 = 1100012

        ''' <summary>
        ''' �o�^�����ŃG���[���������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        routeC013 = 1100013

        ''' <summary>
        ''' �X�V�����ŃG���[���������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        routeC014 = 1100014

        ''' <summary>
        ''' �f�[�^�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �f�[�^�o�^���s�ėp���b�Z�[�W
        ''' </remarks>
        FailedAdd = 1100015

        ''' <summary>
        ''' �f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �폜���s�ėp���b�Z�[�W
        ''' </remarks>
        FailedDelete = 1100016

        ''' <summary>
        ''' �g�D���җ����̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �R���{�{�b�N�X�Ɋi�[����g�D���җ����f�[�^�̎擾�Ɏ��s
        ''' </remarks>
        FailedGetInnavationDate = 1100017

        ''' <summary>
        ''' �J�e�S���f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �J�e�S���f�[�^�̍쐬�Ɏ��s
        ''' </remarks>
        FeiledGetCategory = 1100018

        ''' <summary>
        ''' �f�[�^�R�s�[�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �f�[�^�̃R�s�[�Ɏ��s
        ''' </remarks>
        FailedCopy = 1100019

        ''' <summary>
        ''' �^�p�ݒ�f�[�^�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[���ڍ׃f�[�^�̍쐬�Ɏ��s
        ''' </remarks>
        FeiledAddFormDetaile = 1100020

        ''' <summary>
        ''' �t�H�[���̏ڍ׃f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[���ڍ׃f�[�^�̍쐬�Ɏ��s
        ''' </remarks>
        FeiledGetFormHeader = 1100021

        ''' <summary>
        ''' ���[�g�̏ڍ׃f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[���ڍ׃f�[�^�̍쐬�Ɏ��s
        ''' </remarks>
        FeiledGetRouteHeader = 1100022

        ''' <summary>
        ''' �g�p�t�H�[���̃f�[�^�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[�������f�[�^(EGGA0007)�̍X�V�Ɏ��s
        ''' </remarks>
        FeiledUpdateJoinForm = 1100023

        ''' <summary>
        ''' �g�p���[�g�̃f�[�^�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[�������f�[�^(EGGA0007)�̍X�V�Ɏ��s
        ''' </remarks>
        FeiledUpdateJoinRoute = 1100024

        ''' <summary>
        ''' �r���[���f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[���ڍ׃f�[�^�̍쐬�Ɏ��s
        ''' </remarks>
        FeiledGetView = 1100025

        ''' <summary>
        ''' �̔ԍ��ڃf�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[���ڍ׃f�[�^�̍쐬�Ɏ��s
        ''' </remarks>
        FeiledGetDocumentNumber = 1100026

        ''' <summary>
        ''' �V�X�e���G���[�ł��B�\�����ʃG���[���������܂����B
        ''' </summary>
        ''' <remarks>
        ''' ���̑��̃V�X�e���G���[��
        ''' </remarks>
        SystemUnKnownError = 1100027

        ''' <summary>
        ''' �t�H�[�������J���ׁ̈A�폜�ł��܂���ł����B
        ''' </summary>
        ''' <remarks>
        ''' �^�p�ݒ��ʂŁA�t�H�[�����u�����J����v�ɐݒ肵�Ă���Ƃ��́A
        ''' ���[�g�t�H�[����ʂ���A�폜�`�F�b�N������
        ''' </remarks>
        FailedNotDelete = 1100028

        ''' <summary>
        ''' �����v���p�e�B���o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �o�^�{�^���N���b�N��Ridoc�����v���p�e�B���o�^�Ɏ��s
        ''' </remarks>
        DocPropEntryFailed = 1100029

        ''' <summary>
        ''' �����v���p�e�B���o�^�p�f�[�^�쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �o�^�{�^���N���b�N��Ridoc�����v���p�e�B���o�^�p�f�[�^�쐬�Ɏ��s
        ''' </remarks>
        DocPropEntryDataFailed = 1100030

        ''' <summary>
        ''' �����^�C�v�ꗗ�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �����^�C�v�ꗗ�R���{�p�̃f�[�^�擾�Ɏ��s
        ''' </remarks>
        GetDocPropListFailed = 1100031

        ''' <summary>
        ''' �����v���p�e�B�A�g���擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[�����[�h���ɕ����v���p�e�B�E�t�H�[�����擾���A
        ''' ���[�U�[�R���g���[���\���Ɏ��s
        ''' </remarks>
        GetDataFailed = 1100032

        ''' <summary>
        ''' �t�H�[���f�[�^��擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[�����[�h���ɕ����v���p�e�B�E�t�H�[�����擾���A
        ''' ���[�U�[�R���g���[���\���Ɏ��s
        ''' </remarks>
        GetFormDataFailed = 1100033

        ''' <summary>
        ''' �L���r�l�b�g�ꗗ���擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �L���r�l�b�g�ꗗ���擾���̓��G���[
        ''' </remarks>
        GetCabListFailed = 1100034

        ''' <summary>
        ''' �V�X�e���G���[�ł��B�Ǘ��҂ɖ₢���킹�ĉ������B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[����̂��̑��̃G���[
        ''' </remarks>
        SystemError = 1100035

        ''' <summary>
        ''' �\�����ʃG���[���������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        routeEX00 = 1100036

        ''' <summary>
        ''' �g�p�t�H�[���̊����f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[�������f�[�^(EGGA0007)�̎擾�Ɏ��s
        ''' </remarks>
        FeiledGetJoinForm = 1100037

        ''' <summary>
        ''' �g�p���[�g�̊����f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[�������f�[�^(EGGA0007)�̎擾�Ɏ��s
        ''' </remarks>
        FeiledGetJoinRoute = 1100038

        ''' <summary>
        ''' �g�p���[�g�E�t�H�[���̊����f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[�������f�[�^(EGGA0007)�̍폜�Ɏ��s
        ''' </remarks>
        FeiledDeleteJoinData = 1100039

        ''' <summary>
        ''' �g�p���[�g�E�t�H�[���̊����f�[�^�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[�������f�[�^(EGGA0007)�̓o�^�Ɏ��s
        ''' </remarks>
        FeiledAddJoinData = 1100040

        ''' <summary>
        ''' �^�p�ݒ�f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks>
        ''' �t�H�[���ڍ׃f�[�^�̎擾�Ɏ��s
        ''' </remarks>
        FeiledGetFormDetaile = 1100041

    End Enum

#End Region

#Region " VFAX "

    ''' <summary>
    ''' VFAX �v���W�F�N�g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFAX]

        ''' <summary>
        ''' �e���v���[�g�̂��ߌ�ō폜���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 1110000

    End Enum

#End Region

#Region " VALP "

    ''' <summary>
    ''' VALP �v���W�F�N�g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VALP]

        ''' <summary>
        ''' �e���v���[�g�̂��ߌ�ō폜���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 1120000

    End Enum

#End Region

#Region " ACAB "

    ''' <summary>
    ''' ACAB �v���W�F�N�g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [ACAB]

        ''' <summary>
        '''�A�v���P�[�V�������s���ɃG���[���������܂����B{0}�Ǘ��҂ɖ⍇���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        SytemError = 1140001

    End Enum

#End Region

#Region " VRAC "

    ''' <summary>
    ''' R@bitFlow AccountConverter �v���W�F�N�g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRAC]

        ''' <summary>
        ''' �A�g�������s�̃��b�Z�[�W
        ''' </summary>
        Msg0001 = 1160001

        ''' <summary>
        ''' �����������s�̃��b�Z�[�W
        ''' </summary>
        Msg0002 = 1160002


    End Enum

#End Region

#Region " VANC "

    ''' <summary>
    ''' R@bitFlow NotesConveter �v���W�F�N�g�̃G���[���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VANC]

        ''' <summary>
        '''�A�v���P�[�V�������s���ɃG���[���������܂����B{0}�Ǘ��҂ɖ⍇���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        SytemError = 1180001

    End Enum

#End Region
End Namespace


