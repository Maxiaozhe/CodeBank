Option Compare Binary
Option Explicit On
Option Strict On

Imports System

Namespace Exception
#Region " Common "

    ''' <summary>
    ''' MCOM �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [Common]

        ''' <summary>
        ''' �J�e�S���g�����o�^�G���[
        ''' </summary>
        ''' <remarks></remarks>
        CategoryInsertError = 2010001

        ''' <summary>
        ''' �Y������f�[�^�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DataNothing = 2010002

    End Enum

#End Region

#Region " CEMV "

    ''' <summary>
    ''' CEMV �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [CENV]

        ''' <summary>
        ''' �Y������f�[�^�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ExistDataNotFoundException = 2020001

        ''' <summary>
        ''' �Y�����镡���̃f�[�^����������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DuplicateDataFoundException = 2020002

        ''' <summary>
        ''' �i�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SyncFailedException = 2020003

        ''' <summary>
        ''' �J�e�S���̈ړ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedMoveParentCategoryException = 2020004

        ''' <summary>
        ''' �J�e�S���̍폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedRemoveCategoryException = 2020005

        ''' <summary>
        ''' �C���X�^���X�̍Đ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ReviveFailedException = 2020006

        ''' <summary>
        ''' �f�[�^�̓Ǎ��݂Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DataNotReadException = 2020007

        ''' <summary>
        ''' �V�K�C���X�^���X�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InstanceCanNotMakeException = 2020008

        ''' <summary>
        ''' ���W�X�g���ɏ������ތ���������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        LackingAuthority = 2020009

        ''' <summary>
        ''' ���W�X�g����񂪊Ԉ���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        RegistryFailure = 2020010

        ''' <summary>
        ''' Rabit.Conf���ǂݍ��߂܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotReadRabitConf = 2020011

    End Enum

#End Region

#Region " RFLW "

    ''' <summary>
    ''' RFLW �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFLW]

        ''' <summary>
        ''' �K�{���ڂɒl�����͂���Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MustInputUnsatedException = 2030001

        ''' <summary>
        ''' �A�J�E���g�����b�N����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AccountLockException = 2030002

        ''' <summary>
        ''' ���񃍃O�C���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        FirstLoginException = 2030003

        ''' <summary>
        ''' �V�X�e���Ǘ��҂ɂ��p�X���[�h�ύX�̗v��������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ImpositionChangePasswordException = 2030004

        ''' <summary>
        ''' �ݒ肵���p�X���[�h�ɐ��l���܂܂�Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NumberPasswordException = 2030005

        ''' <summary>
        ''' �ݒ肵���p�X���[�h�ɋL�����܂܂ꂢ�܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MarkPasswordException = 2030006

        ''' <summary>
        ''' �ݒ肵���p�X���[�h���p�召�������݂��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CapsPasswordException = 2030007

        ''' <summary>
        ''' �ݒ肵���p�X���[�h�Ƀ��[�U�h�c���܂܂�Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        UserIdPasswordException = 2030008

        ''' <summary>
        ''' ����̕��������񐔌J�Ԃ���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        RepeatStringPasswordException = 2030009

        ''' <summary>
        ''' �ݒ肵���p�X���[�h�����Œጅ����菬�����l�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        MinPasswordException = 2030010

        ''' <summary>
        ''' �ݒ肵���p�X���[�h�����ő包�����傫���l�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        MaxPasswordException = 2030011

        ''' <summary>
        ''' �ݒ肵���p�X���[�h�ɋ֑��������܂܂�Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        WrapPasswordException = 2030012

        ''' <summary>
        ''' �ݒ肵���p�X���[�h���ߋ��Ɏg�p����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        HistoryPasswordException = 2030013

        ''' <summary>
        ''' �p�X���[�h�̗L���������؂�܂����B
        ''' </summary>
        ''' <remarks></remarks>
        OutOfDateException = 2030014

        ''' <summary>
        ''' �V�X�e�����T�|�[�g�ł�����t�͈̔͂𒴂��܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InputDateOutOfRangeException = 2030015

        ''' <summary>
        ''' �������a����͂���Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ChangeGregorianExFailedException = 2030016

        ''' <summary>
        ''' ���͌������e�͈͂𒴂��܂����B
        ''' </summary>
        ''' <remarks></remarks>
        OverFlowException = 2030017

        ''' <summary>
        ''' �������fGUI�R���g���[���Ń��b�Z�[�W�{�b�N�X���w�肳��܂����B
        ''' </summary>
        ''' <remarks></remarks>
        UserEstablishedMessageException = 2030018

        ''' <summary>
        ''' �V�X�e���ɂ��ۑ������f����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        StopSaveException = 2030019

        ''' <summary>
        ''' �J�n���A�I���������ꂩ�������͂ł̓o�^�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        AnotherNonInputItemException = 2030020

        ''' <summary>
        ''' �J�n���͏I�����ȑO�̓��t����͂��Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        ChangeDateItemException = 2030021

        ''' <summary>
        ''' �J�n������I�����͈̔͂�{0}�N�����ɂ��ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        RangeOverDateItemException = 2030022

        ''' <summary>
        ''' �݌v���̃p�����[�^���s���S�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        FieldParamIncompleteException = 2030023

        ''' <summary>
        ''' �t�B�[���h�f�[�^�̎擾�Ɏ��s���܂���
        ''' </summary>
        ''' <remarks></remarks>
        FieldValueGetException = 2030024

        ''' <summary>
        ''' �t�B�[���h���̎擾�Ɏ��s���܂���
        ''' </summary>
        ''' <remarks></remarks>
        FieldInfoGetException = 2030025

        ''' <summary>
        ''' �r���[SQL�����݂��܂���
        ''' </summary>
        ''' <remarks></remarks>
        ViewSqlNotExistException = 2030026

        ''' <summary>
        ''' Type�v���p�e�B�ɐݒ肳�ꂽ�l���K�p����܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        TypePropUseException = 2030027

        ''' <summary>
        ''' DBGUI�ŗL���̐ݒ�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DBGUISetException = 2030028

        ''' <summary>
        ''' ���|�[�g���C�A�E�g�t�@�C�������݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonRPXFileException = 2030029

        ''' <summary>
        ''' ���͌������e�͈͂𒴂��܂����B
        ''' </summary>
        ''' <remarks></remarks>
        Int32OverFlowException = 2030030

        ''' <summary>
        ''' ���͌������e�͈͂𒴂��܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DecimalOverFlowException = 2030031

        ''' <summary>
        ''' ����ł���f�[�^�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonDataPrintException = 2030032

        ''' <summary>
        ''' �s���Ȑ��l�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        NumericErrorException = 2030033

        ''' <summary>
        ''' ���͂��ꂽ�l�͕s���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        ObliquityValueException = 2030034

    End Enum

#End Region

#Region " MEGG "

    ''' <summary>
    ''' MEGG �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MEGG]

        ''' <summary>
        ''' �����K�w�f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        BbsDocLevelErrException = 2040001

        ''' <summary>
        ''' �ԐM�{�^���̕\�����f�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        BbsReplyDispErrException = 2040002

        ''' <summary>
        ''' ���̃��[�g�͎g�p�ł��܂���B�V�K�쐬�{�^���Ń��[�g��ݒ肷�邩�A�Ǘ��҃c�[���ōĒ�`����K�v������܂��B
        ''' </summary>
        ''' <remarks></remarks>
        CreateSnapShotFailedException = 2040003

        ''' <summary>
        ''' ���[�g�P�̂�������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        RoutingDataNotFindException = 2040004

        ''' <summary>
        ''' �f�[�^�̓Ǎ��݂Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DataNotReadException = 2040005

        ''' <summary>
        ''' �\���҂����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MakeNUserNotFindException = 2040006

        ''' <summary>
        ''' ���̏��F�҂����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NextNUserNotFindException = 2040007

        ''' <summary>
        ''' �O�̏��F�҂����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        PrevNUserNotFindException = 2040008

        ''' <summary>
        ''' �t�H�[���ڍ׊Ǘ��e�[�u���̍X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedUpdateException = 2040009

        ''' <summary>
        ''' �t�H�[���ڍ׊Ǘ��e�[�u���̒ǉ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedInsertException = 2040010

        ''' <summary>
        ''' �C���X�^���X�̍Đ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ReviveFailedException = 2040011

        ''' <summary>
        ''' ���[�g�̈ꗗ�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        RouteListNotFindException = 2040012

        ''' <summary>
        ''' ACL�̈ꗗ�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ACLNotFindException = 2040013

        ''' <summary>
        ''' ���[�����M�ꗗ�̓o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        EntrySendMailListException = 2040014

        ''' <summary>
        ''' �������[�g�ԍ��̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        UninonRouteIDNotFindException = 2040015

        ''' <summary>
        ''' ���F�҈ꗗ�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        NUserNotFindException = 2040016

        ''' <summary>
        ''' ���������̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SearchConditionCanNotMakeException = 2040017

        ''' <summary>
        ''' �r���[�f�[�^���oSQL�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ViewSqlCanNotMakeException = 2040018

        ''' <summary>
        ''' �V���������̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        CreateDocumentFailedException = 2040019

        ''' <summary>
        ''' �C���f�b�N���o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocCreateIndexErrException = 2040020

        ''' <summary>
        ''' "�C���f�b�N���폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocDelIndexErrException = 2040021

        ''' <summary>
        ''' �i�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SyncFailedException = 2040022

        ''' <summary>
        ''' �A�Ԃ��L�������𒴂��܂����B
        ''' </summary>
        ''' <remarks></remarks>
        NumberOutOfRangeException = 2040023

        ''' <summary>
        ''' �w�肵�������ԍ��͊��Ɏg�p����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNumberDuplicatedException = 2040024

        ''' <summary>
        ''' �w�肳�ꂽ�J�����ƕύX�l�̑������Ⴂ�܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgClumTypeErrException = 2040025

        ''' <summary>
        ''' �����I�[�o�[�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgClumTypeOverException = 2040026

        ''' <summary>
        ''' �w�肳�ꂽ�J������������܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgClumNotFindException = 2040027

        ''' <summary>
        ''' �\�����Ȃ��G���[���������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgAbnomalException = 2040028

        ''' <summary>
        ''' ��t�S���җp�̔r���X�V�̏��������s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocLockUpdateException = 2040029

        ''' <summary>
        ''' �V�K�C���X�^���X�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InstanceCanNotMakeException = 2040030

        ''' <summary>
        ''' �������[�g�P�̂�������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        UnionRoutingDataNotFindException = 2040031

        ''' <summary>
        ''' ���������s���錠��������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        PermissionDeniedException = 2040032

        ''' <summary>
        ''' �۔F�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DenyFailedException = 2040033

        ''' <summary>
        ''' ������������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNotFindException = 2040034

        ''' <summary>
        ''' �\�������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MakeFailedException = 2040035

        ''' <summary>
        ''' �R�������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AcceptFailedException = 2040036

        ''' <summary>
        ''' ���F�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SubmitFailedException = 2040037

        ''' <summary>
        ''' ���߂������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        RemandFailedException = 2040038

        ''' <summary>
        ''' �X�V�ݒ�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetErrLumpUpdateItemSetException = 2040039

        ''' <summary>
        ''' �X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ErrLumpUpdateException = 2040040

        ''' <summary>
        ''' ���[�g���̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MakeEggFailedException = 2040041

        ''' <summary>
        ''' �Y�t�t�@�C���폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DelAddFileException = 2040042

        ''' <summary>
        ''' �Y�t�t�@�C���ǉ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InsAddFileException = 2040043

        ''' <summary>
        ''' �{�^���̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MakeButtonFailedException = 2040044

        ''' <summary>
        ''' �o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ReviveHolidayItemException = 2040045

        ''' <summary>
        ''' �����X�e�[�^�X���s���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        InvalidStatusException = 2040046

        ''' <summary>
        ''' �f�t�H���g����ID�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DefaultSysBlgErrException = 2040047

        ''' <summary>
        ''' ��������f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        RouteTermsPointErrException = 2040048

        ''' <summary>
        ''' �\���ҏ��̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        RequestDataNotException = 2040049

        ''' <summary>
        ''' ���F�L�����̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        TdirectorDayErrException = 2040050

        ''' <summary>
        ''' ���[���̑��M�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MailFailedException = 2040051

        ''' <summary>
        ''' �����̈ꗗ�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentListNotFindException = 2040052

        ''' <summary>
        ''' ���J�f���̔��f�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocWfAndBbsErrException = 2040053

        ''' <summary>
        ''' ���F�������瓊�e�����ւ̍X�V�����s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocWfAndBbsUpErrException = 2040054

        ''' <summary>
        ''' �Q�ƌ��`�F�b�N�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        PermissionCheckFailedException = 2040055

        ''' <summary>
        ''' �Ǘ��҃��[�h�̔��f�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        WfAdminErrException = 2040056

        ''' <summary>
        ''' �A�Z���u���̃��\�b�h�ďo���Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InvokeAbortException = 2040057

        ''' <summary>
        ''' �������̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentDataNotFindException = 2040058

        ''' <summary>
        ''' ���ʕ����̍ŏI�X�V�����擾�ł��܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        ErrLumpGetLastUpdateException = 2040059

        ''' <summary>
        ''' �f�t�H���g�����ݒ�̏��������s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DefSysBlgUpdateException = 2040060

        ''' <summary>
        ''' ��щz�����F���f�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocJumpErrException = 2040061

        ''' <summary>
        ''' ��������̃f�[�^�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ConditionNotFindException = 2040062

        ''' <summary>
        ''' ���e�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ContributionFailedException = 2040063

        ''' <summary>
        ''' �ꊇ���F�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        PackageAcceptFailedException = 2040064

        ''' <summary>
        ''' �ꊇ���߂������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        PackageRemandFailedException = 2040065

        ''' <summary>
        ''' ���[�g�ԍ��̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        RouteIDNotFindException = 2040066

        ''' <summary>
        ''' �������[�g�̈ꗗ�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        UninonRouteListNotFindException = 2040067

        ''' <summary>
        ''' �x�[�X�N���X�Ń��o�C�u�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        BaseClassReviveFailedException = 2040068

        ''' <summary>
        ''' ���[�N�t���[��Ƀ��[�U�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NUserNotFindOnRouteException = 2040069

        ''' <summary>
        ''' �J�����g���F�҂̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        CurrentNUserNotFindException = 2040070

        ''' <summary>
        ''' ���[�g�̍č쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        RouteRemakeFailedException = 2040071

        ''' <summary>
        ''' �w�肳�ꂽ�����h�c���s���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        DirtyDocumentSeedException = 2040072

        ''' <summary>
        ''' �����ݏC�����������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        CutintoOnFailedException = 2040073

    End Enum

#End Region

#Region " MFRM "

    ''' <summary>
    ''' MFRM �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MFRM]

        ''' <summary>
        ''' �C���X�^���X�̍Đ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ReviveFailedException = 2050001

        ''' <summary>
        ''' �f�[�^�̓Ǎ��݂Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DataNotReadException = 2050002

        ''' <summary>
        ''' �V�K�C���X�^���X�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InstanceCanNotMakeException = 2050003

        ''' <summary>
        ''' �i�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SyncFailedException = 2050004

        ''' <summary>
        ''' �r���[�r�p�k���̓o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        EntryViewSqlFailedException = 2050005

        ''' <summary>
        ''' �t�H�[�����ڂ��폜����Ă��܂��B{0}{1}
        ''' </summary>
        ''' <remarks></remarks>
        DataNothingException = 2050006

        ''' <summary>
        ''' �r���[���ڃO���[�v�����̓o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ViewGroupInfoSyncFailedException = 2050007

        ''' <summary>
        ''' �r���[�t�H�[���A���L�[���̓o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ViewJoinKeySyncFailedException = 2050008

        ''' <summary>
        ''' �r���[�i���݃u���b�N���̓o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ViewRefineBlockSyncFailedException = 2050009

        ''' <summary>
        ''' �r���[�i���ݍ��ڏ��̓o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ViewRefineItemSyncFailedException = 2050010

        ''' <summary>
        ''' �����r���[�����֘A���̓o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewAttrInfoSyncFailedException = 2050011

        ''' <summary>
        ''' �����r���[���ڏ��̓o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewItemInfoSyncFailedException = 2050012

        ''' <summary>
        ''' �r���[�T�u�A�v�����̓o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ViewSubAppSyncFailedException = 2050013

        ''' <summary>
        ''' �������V�X�e���ŕێ��ł���T�C�Y�𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        RecordSizeOutOfRangeException = 2050014

        ''' <summary>
        ''' �������V�X�e���ŕێ��ł��鍀�ڐ��𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        FieldCountOutOfRangeException = 2050015

        ''' <summary>
        ''' �t�H�[���Ƀ��[�N�t���[���ږ��������͏d���������ږ���t���鎖�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FieldNameRepeatedException = 2050016

        ''' <summary>
        ''' �t�H�[������폜���ꂽ���ڂ��r���[�Ŏg�p����Ă��܂��B�r���[�G�f�B�^�ŏC�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        CheckViewSQLErrorException = 2050017

        ''' <summary>
        ''' �r���[�̐ݒ�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ViewSetException = 2050018

        ''' <summary>
        ''' �w�肳�ꂽ�t�H�[���h�c�̃f�[�^�����݂��܂���B{0}{1}
        ''' </summary>
        ''' <remarks></remarks>
        FormNotFoundException = 2050019

        ''' <summary>
        ''' �w�肳�ꂽ�t�H�[�����ڂh�c�̃f�[�^�����݂��܂���B{0}{1}
        ''' </summary>
        ''' <remarks></remarks>
        FieldNotFoundException = 2050020

        ''' <summary>
        ''' �r���[�i���ݏ������̓o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ViewRefineCondSyncFailedException = 2050021

        ''' <summary>
        ''' �\���̃p�����[�^�ɐ��l�ȊO�̒l���ݒ肳��Ă��܂��B{0}
        ''' </summary>
        ''' <remarks></remarks>
        ReservedWordArgumentException = 2050022

        ''' <summary>
        ''' {0}�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FormDataNotReadException = 2050023

        ''' <summary>
        '''�R�s�[��t�H�[�������݂��܂���B{0}
        ''' </summary>
        ''' <remarks></remarks>
        CopyFormNotExist = 2050024

        ''' <summary>
        '''�R�s�[��t�H�[�����������݂��܂��B{0}
        ''' </summary>
        ''' <remarks></remarks>
        MultiCopyFormExisted = 2050025

        ''' <summary>
        '''�V�X�e�����ږ��̂̎擾�Ɏ��s���܂����B{0}
        ''' </summary>
        ''' <remarks></remarks>
        GetSystemFieldNameFailed = 2050026

        ''' <summary>
        '''����ID�̎擾�Ɏ��s���܂����B{0}
        ''' </summary>
        ''' <remarks></remarks>
        GetFieldIdFailed = 2050027

        ''' <summary>
        '''���������SQL��������ɓ��삵�܂���ł����B\n[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        SqlError = 2050028

        ''' <summary>
        '''��������Ă���r���[�̃r���[SQL��񂪈ُ�ł��B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewSqlError = 2050029

        ''' <summary>
        '''�Y���̃u���b�N��񂪈ُ�ł��B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewBlockError = 2050030

        ''' <summary>
        '''�r���[�i���ݍ��ڂ̎��̒l���ُ�ł��B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewTPFormulaError = 2050031

        ''' <summary>
        '''��������Ă���r���[�̏�񂪑��݂��܂���B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewInfoNotExist = 2050032

        ''' <summary>
        '''�ݒ肳��Ă��錋���r���[���ڏ�񂪈ُ�ł��B�\����=[{0}]�̃f�[�^�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ViewSortDataNotExist = 2050033

        ''' <summary>
        '''�ݒ肳��Ă��錋���r���[�O���[�v���ڏ�񂪈ُ�ł��B�\����=[{0}]�̃f�[�^�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ViewGroupSortDataNotExist = 2050034

        ''' <summary>
        '''�w�肳�ꂽ�t�H�[���h�c�̃f�[�^�����݂��܂���B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        FormIdDataNotExist = 2050035

        ''' <summary>
        '''�w�肳�ꂽ�f�t�h�h�c�̃f�[�^�����݂��܂���B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        GuiidDataNotExist = 2050036

        ''' <summary>
        '''�L����RES�t�H�[�����������݂��܂��B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        MultiRESFormExisted = 2050037

        ''' <summary>
        '''�I�����ꂽGUI�̏ڍ׏�񂪎擾�ł��܂���ł����B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        GetGuiInfoFailed = 2050038


    End Enum

#End Region

#Region " MJNJ "

    ''' <summary>
    ''' MJNJ �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MJNJ]

        ''' <summary>
        ''' ���X�g����̃f�[�^�i�[�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SetDataFailedException = 2060001

        ''' <summary>
        ''' �C���X�^���X�̍Đ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ReviveFailedException = 2060002

        ''' <summary>
        ''' �L�[���擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetSeedFailedException = 2060003

        ''' <summary>
        ''' �V�K�C���X�^���X���쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InstanceFailedException = 2060004

        ''' <summary>
        ''' ���X�g����̃f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetDataFailedException = 2060005

        ''' <summary>
        ''' �r�p�k�\���̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SqlSyntaxException = 2060006

        ''' <summary>
        ''' �v�����p�N���X�ւ̕ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ConvertFlowItemException = 2060007

        ''' <summary>
        ''' �����f�[�^�擾���̕ϊ������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AffBreakInfoException = 2060008

        ''' <summary>
        ''' �����f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetSystemUserException = 2060009

        ''' <summary>
        ''' ���[�g���݃`�F�b�N�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        RouteCheckedExistenceExceptin = 2060010

        ''' <summary>
        ''' List�v���p�e�B�f�[�^�̏������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InitPropertyException = 2060011

        ''' <summary>
        ''' �����f�[�^�̃c���[�m�[�h�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SystemUserSelectedNodeException = 2060012

        ''' <summary>
        ''' �����f�[�^�̃c���[�m�[�h�X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SystemUserAddedNodeException = 2060013

        ''' <summary>
        ''' �����f�[�^�̃c���[�m�[�h�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SystemUserRemoveedNodeException = 2060014

        ''' <summary>
        ''' �c���[�m�[�h���珊���f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetSystemUserItemFromNodeException = 2060015

        ''' <summary>
        ''' ����������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ErrorNoAuthorityException = 2060016

        ''' <summary>
        ''' �l�ꗗ�̃f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetUserListException = 2061001

        ''' <summary>
        ''' �l�f�[�^�V�K�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        UserInsertException = 2061002

        ''' <summary>
        ''' �l�f�[�^�X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        UserUpdateException = 2061003

        ''' <summary>
        ''' �l�f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        UserDeleteException = 2061004

        ''' <summary>
        ''' ���O�C���h�c�̃`�F�b�N�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        LoginIdException = 2061005

        ''' <summary>
        ''' �l�f�[�^�Ə����f�[�^�̊֘A�t���Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        UserNodeNotConnectedException = 2061006

        ''' <summary>
        ''' �����f�[�^�i�[�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AffStorageFailedException = 2061007

        ''' <summary>
        ''' �����̑��݃`�F�b�N�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DocumentCheckedExistenceExcepton = 2061008

        ''' <summary>
        ''' �����f�[�^�̊֘A�t���Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        LinkedAffiliationException = 2061009

        ''' <summary>
        ''' �����ꗗ�̃f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetAffiliationListException = 2061010

        ''' <summary>
        ''' �֘A���鏊���f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetAffiliationException = 2061011

        ''' <summary>
        ''' �����f�[�^�V�K�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AffiliationInsertException = 2061012

        ''' <summary>
        ''' �����f�[�^�X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AffiliationUpdateException = 2061013

        ''' <summary>
        ''' �����f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AffiliationDeleteException = 2061014

        ''' <summary>
        ''' �c���[�m�[�h����㗝�҃f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DeputySelectedNodeException = 2061015

        ''' <summary>
        ''' �㗝�҃f�[�^�̃c���[�m�[�h�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DeputyAddedNodeException = 2061016

        ''' <summary>
        ''' �㗝�҃f�[�^�̃c���[�m�[�h�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DeputyRemovedNodeException = 2061017

        ''' <summary>
        ''' �g�D�ꗗ�̃f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetGroupListException = 2062001

        ''' <summary>
        ''' �g�D�f�[�^�V�K�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GroupInsertException = 2062002

        ''' <summary>
        ''' �g�D�f�[�^�X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GroupUpdateException = 2062003

        ''' <summary>
        ''' �g�D�f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GroupDeleteException = 2062004

        ''' <summary>
        ''' �g�D�f�[�^�Ə����f�[�^�̊֘A�t���Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GroupNodeNotConnectedException = 2062005

        ''' <summary>
        ''' �O���[�v�N���X�ւ̕ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ConvertGroupException = 2062006

        ''' <summary>
        ''' ����K�w�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SameLevelSearchException = 2062007

        ''' <summary>
        ''' �g�D�}�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        OrgTreeNotCreatedException = 2062008

        ''' <summary>
        ''' �O���[�v�}�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GrpTreeNotCreatedException = 2062009

        ''' <summary>
        ''' �`�b�k�}�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AclTreeNotCreatedException = 2062010

        ''' <summary>
        ''' ���̃t���p�X�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ShortNameFullException = 2062011

        ''' <summary>
        ''' �O���[�v�h�c�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GroupIdNotObtainedException = 2062012

        ''' <summary>
        ''' �p���t���p�X�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        EnglishNameFullException = 2062013

        ''' <summary>
        ''' �Y���O���[�v���牺�̌l���擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AllMemberOfGroupException = 2062014

        ''' <summary>
        ''' �����f�[�^���݃`�F�b�N�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AffiliationCheckedExistenceExcepton = 2062015

        ''' <summary>
        ''' �����f�[�^����̃O���[�v�Ɩ�E���擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GrpAndPosNotObtainedException = 2062016

        ''' <summary>
        ''' �q�m�[�h�쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ChildNodeNotCreatedException = 2062017

        ''' <summary>
        ''' ���p�\�O���[�v�ꗗ�p�o�b�t�@�e�[�u���쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        UseGroupDatasetNotCreatedException = 2062018

        ''' <summary>
        ''' �A�h���X�ꗗ�p�o�b�t�@�e�[�u���쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MailDatasetNotCreatedException = 2062019

        ''' <summary>
        ''' �폜�ꊇ�ꗗ�p�o�b�t�@�e�[�u���쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DeleteGroupDatasetNotCreatedException = 2062020

        ''' <summary>
        ''' ����K�w���[���[�g]�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        CheckLevelDataException = 2062021

        ''' <summary>
        ''' �g�D�ꊇ�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GroupTruncateException = 2062022

        ''' <summary>
        ''' �g�D�R�[�h�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GroupCodeNotObtainedException = 2062023

        ''' <summary>
        ''' ��E�ꗗ�̃f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetPositionListException = 2063001

        ''' <summary>
        ''' ��E�f�[�^�V�K�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        PositionInsertException = 2063002

        ''' <summary>
        ''' ��E�f�[�^�X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        PositionUpdateException = 2063003

        ''' <summary>
        ''' ��E�f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        PositionDeleteException = 2063004

        ''' <summary>
        ''' �q�m�[�h�쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ChildPositionNodeMakeFailedException = 2063005

        ''' <summary>
        ''' ��E�}�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        PositionTreeNotCreatedException = 2063006

        ''' <summary>
        ''' ��E�R�[�h�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        PositionCodeNotObtainedException = 2063007

        ''' <summary>
        ''' �㗝�҈ꗗ�̃f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetDeputyListException = 2064001

        ''' <summary>
        ''' �㗝�҃f�[�^�V�K�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DeputyInsertException = 2064002

        ''' <summary>
        ''' �㗝�҃f�[�^�X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DeputyUpdateException = 2064003

        ''' <summary>
        ''' �㗝�҃f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DeputyDeleteException = 2064004

        ''' <summary>
        ''' �㗝�҂̗L�����Ԃ��㗝�ғ��l�̏������Ԃ��z���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        OverRangeBelongException = 2065001

        ''' <summary>
        ''' �����h�c����̌l�f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetNFLOWUserException = 2065002

        ''' <summary>
        ''' �O���[�v�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ErrorNotExistGroupException = 2065003

        ''' <summary>
        ''' �Y���O���[�v���牺�̌l���擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetAllMemberInfoFromGroupException = 2065004

        ''' <summary>
        ''' �Y���f�[�^��������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ErrorNoDataException = 2065005

        ''' <summary>
        ''' ���O�C���Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedLoginException = 2065006

        ''' <summary>
        ''' �g�D���ҏ������������Ȃ���Ԃŉ��ғ����}���Ă��邽�߁A���O�C���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ErrorDateInReorganizationException = 2065007

        ''' <summary>
        ''' �p�X���[�h������������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ErrorUnlikePasswordException = 2065008

        ''' <summary>
        ''' �{��������������܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ErrorManyMainException = 2065009

        ''' <summary>
        ''' ����������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ErrorNotBelongException = 2065010

        ''' <summary>
        ''' �{��������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ErrorNotMainException = 2065011

        ''' <summary>
        ''' ���O�C���`�F�b�N�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedCheckLoginUserException = 2065012

        ''' <summary>
        ''' ���[�U�[�h�c����̌l�f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetNFLOWUserByPersonException = 2065013

        ''' <summary>
        ''' �l�̏����ꗗ�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetMyPositionException = 2065014

        ''' <summary>
        ''' �����̑㗝�҈ꗗ�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetMyDeputyException = 2065015

        ''' <summary>
        ''' ���ʑw�O���[�v�ꗗ�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetNFLOWGroupListException = 2065016

        ''' <summary>
        ''' ��ʃO���[�v�ꗗ�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetParentNFLOWGroupListException = 2065017

        ''' <summary>
        ''' �J�e�S���h�c����̃O���[�v�ꗗ�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetCategoryNFLOWGroupListException = 2065018

        ''' <summary>
        ''' �J�e�S���ꗗ�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetCategoryListException = 2065019

        ''' <summary>
        ''' ���p�\�O���[�v�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetUsefulGroupException = 2065020

        ''' <summary>
        ''' �O���[�v�h�c�Ɩ�E�h�c����̑g�D���擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetNFLOWGroupFromPositionException = 2065021

        ''' <summary>
        ''' �O���[�v�h�c�Ɩ�E�h�c����̏������擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetNFLOWUserListByGPException = 2065022

        ''' <summary>
        ''' �p�X���[�h�X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedSetUserPasswordException = 2065023

        ''' <summary>
        ''' ���җ����f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedInnovationDateException = 2065024

        ''' <summary>
        ''' �`�c�F�؂Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ErrorCertifyActiveDirectryException = 2065025

        ''' <summary>
        ''' ���[�J�����O�C���ł���̂͊Ǘ��҂����ł��B
        ''' </summary>
        ''' <remarks></remarks>
        ErrorLoginOnlyAdministratorException = 2065026

        ''' <summary>
        ''' R@bitFlow �N���C�A���g�ł́wWFAdmin�x�ł̃��O�C���͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ErrorCannotLoginAdministratorException = 2065027

        ''' <summary>
        ''' �t�@�C�������ݎg�p���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        FileUsedException = 2069001

        ''' <summary>
        ''' �ϊ��Ώۃt�@�C����������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FileNotFoundException = 2069002

        ''' <summary>
        ''' �t�@�C���t�H�[�}�b�g���s���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        FileFormatUncorrectException = 2069003

        ''' <summary>
        ''' �ϊ��Ώۃf�B���N�g����������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        DirectoryNotFoundException = 2069004

        ''' <summary>
        ''' �����f�[�^�̃v���p�e�B�Z�b�g�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ReorganizationPropertyException = 2069005

        ''' <summary>
        ''' �����f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetReorganizationException = 2069006

        ''' <summary>
        ''' �����f�[�^�̍X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ReorganizationUpdateException = 2069007

        ''' <summary>
        ''' �s�����f�[�^�폜�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SweepTrashFailedException = 2069008

        ''' <summary>
        ''' ���[�g�֘A�I�������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ReorganizationRouteConnectedException = 2069009

        ''' <summary>
        ''' �l�֘A�s���ꗗ�擾�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        WrongUserException = 2069010

        ''' <summary>
        ''' ���[�g�֘A�J�n�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        StartRouteConnecedException = 2069011

        ''' <summary>
        ''' ���[�g�R���o�[�g�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        RouteConvertFailedException = 2069012

        ''' <summary>
        ''' �g�D�֘A�J�n�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        StartOrganizationConnectedException = 2069013

        ''' <summary>
        ''' �g�D�֘A�R���o�[�g�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        OrganizationConvertFailedException = 2069014

        ''' <summary>
        ''' �l�֘A�J�n�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        StartMemberConnectedException = 2069015

        ''' <summary>
        ''' �l�֘A�I�������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FinishMemberConnectedException = 2069016

        ''' <summary>
        ''' �����ꗗ�̃f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        GetInnovationListException = 2069017

        ''' <summary>
        ''' �����f�[�^�V�K�o�^�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InnovationInsertException = 2069018

        ''' <summary>
        ''' �����f�[�^�X�V�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InnovationUpdateException = 2069019

        ''' <summary>
        ''' �����f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InnovationDeleteException = 2069020

        ''' <summary>
        ''' �����A�g�D���Ғ��ł��B
        ''' </summary>
        ''' <remarks></remarks>
        EditingOrganizationNowException = 2069021

        ''' <summary>
        ''' ��Ӑ���ᔽ�ł��B
        ''' {0}�ɂ͏d�������l��}�����邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ViolatedUniqueConstraintException = 2069022

    End Enum

#End Region

#Region " VEGG "

    ''' <summary>
    ''' VEGG �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VEGG]

        ''' <summary>
        ''' ���[�g�̈ꗗ�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetFormListException = 2070001

        ''' <summary>
        ''' �t�H�[���̏ڍ׃f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetFormeHeaderException = 2070002

        ''' <summary>
        ''' ���[�g�̏ڍ׃f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetRouteHeaderException = 2070003

        ''' <summary>
        ''' �c���[�̍쐬�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledCreateTreeNodeException = 2070004

        ''' <summary>
        ''' �g�p���[�g�̊����f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetJoinRouteException = 2070005

        ''' <summary>
        ''' �g�p�t�H�[���̊����f�[�^�擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetJoinFormException = 2070006

        ''' <summary>
        ''' �^�p�ݒ�f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetFormDetaileException = 2070007

        ''' <summary>
        ''' �^�p�ݒ�f�[�^�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledAddFormDetaileException = 2070008

        ''' <summary>
        ''' ���[�g�̈ꗗ�̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetRouteListException = 2070009

        ''' <summary>
        ''' �g�p���[�g�E�t�H�[���̊����f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledDeleteJoinDataException = 2070010

        ''' <summary>
        ''' �g�p���[�g�E�t�H�[���̊����f�[�^�폜�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FeiledAddJoinDataException = 2070011



        ''' <summary>
        ''' ���������SQL��������ɓ��삵�܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        SqlError = 2070012

        ''' <summary>
        ''' ���͕����͐����̂ݗL���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        TypeErrorNumber = 2070013

        ''' <summary>
        ''' �\�����ڂɑΏۈȊO�̃t�H�[���̍��ڂ��I������Ă��܂��B[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectErrorView = 2070014

        ''' <summary>
        ''' �O���[�v���ڂɑΏۈȊO�̃t�H�[���̍��ڂ��I������Ă��܂��B[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectErrorGroup = 2070015

        ''' <summary>
        ''' �������ڂɑΏۈȊO�̃t�H�[���̍��ڂ��I������Ă��܂��B[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectErrorCondition = 2070016

        ''' <summary>
        ''' �������Z�b�g�Ώۂ̃r���[���ڏ�񂪑��݂��܂���B[{0}][{1}][{2}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC001 = 2070017

        ''' <summary>
        ''' �������Z�b�g�Ώۂ̃r���[�O���[�v���ڏ�񂪑��݂��܂���B[{0}][{1}][{2}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC002 = 2070018

        ''' <summary>
        ''' �I�����ꂽGUI�̏ڍ׏�񂪎擾�ł��܂���ł����B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC003 = 2070019

        ''' <summary>
        ''' �f�t�H���g�r���[�̂r�p�k�������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        routeC004 = 2070020

        ''' <summary>
        ''' �f�t�H���g�r���[�̐ݒ�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        routeC005 = 2070021

        ''' <summary>
        ''' {0}�F�p�����[�^�ُ�[{1}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC006 = 2070022

        ''' <summary>
        ''' �I�����ꂽ���ڂ��ُ�ł��B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC007 = 2070023

        ''' <summary>
        ''' �I�����ꂽGUI�̏ڍ׏�񂪎擾�ł��܂���ł����B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC008 = 2070024

        ''' <summary>
        ''' �����Ώۂ̃r���[���ڏ�񂪑��݂��܂���B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC009 = 2070025

        ''' <summary>
        ''' �A���^�C�v���I������Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC010 = 2070026

        ''' <summary>
        ''' �I�����ꂽGUI�̏ڍ׏�񂪎擾�ł��܂���ł����B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC011 = 2070027

        ''' <summary>
        ''' �I�����ꂽ�����r���[���ڂɐݒ肳��Ă���l���ُ�ł��I[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC012 = 2070028

        ''' <summary>
        ''' �I�����ꂽ�����r���[���ځi�O���[�v���j�ɐݒ肳��Ă���l���ُ�ł��I[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC013 = 2070029

        ''' <summary>
        ''' �����r���[���ڑI���ُ�I[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC014 = 2070030

        ''' <summary>
        ''' �����Ώۃr���[����G���[[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC015 = 2070031

        ''' <summary>
        ''' �����Ώۃr���[�̒l���s���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        routeC016 = 2070032

        ''' <summary>
        ''' �\���������͂���Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC017 = 2070033

        ''' <summary>
        ''' �I�����ꂽ�\�����͊��ɑ��݂��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeC018 = 2070034

        ''' <summary>
        ''' �r���[�T�u�A�v���}�X�^�[��񂪑��݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC019 = 2070035

        ''' <summary>
        ''' �Ώۂ�RES��񂪈ُ�ł��B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC020 = 2070036

        ''' <summary>
        ''' �폜�Ώۂ̍��ڈꊇ�X�V���ڂ����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC021 = 2070037

        ''' <summary>
        ''' ���ʑw�ɏ�����u���b�N�����݂��Ă�����͍̂폜���邱�Ƃ��ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC022 = 2070038

        ''' <summary>
        ''' �ړ��悪�w�肳��܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        routeC023 = 2070039

        ''' <summary>
        ''' ����K�w�ňړ����邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC024 = 2070040

        ''' <summary>
        ''' �ړ���ɓ����u���b�N���w�肷�邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC025 = 2070041

        ''' <summary>
        ''' �ړ���̓u���b�N�łȂ���΂Ȃ�܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC026 = 2070042

        ''' <summary>
        ''' �ړ���ɁA�ړ������鍀�ڂ̉��ʑw���w�肷�邱�Ƃ͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeC027 = 2070043

        ''' <summary>
        ''' �v���p�e�B�̓��͂ɈႪ����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        routeC028 = 2070044

        ''' <summary>
        ''' {0}�`{1}�̊ԂŐݒ肵�Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        routeC029 = 2070045

        ''' <summary>
        ''' �������ڂɑΏۈȊO�̃t�H�[���̍��ڂ��I������Ă��܂��B[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC030 = 2070046

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 2070047

    End Enum

#End Region

#Region " VGUI "

    ''' <summary>
    ''' VGUI �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VGUI]

        ''' <summary>
        '''���C���t�H�[����񂪈ُ�ł��B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        MainFormInfoException = 2080001

        ''' <summary>
        '''���C���t�H�[�����ڏ�񂪈ُ�ł��B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        MainFormFieldInfoException = 2080002

        ''' <summary>
        '''�w�肳�ꂽ�r���[�̏�񂪈ُ�ł��B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewInfoException = 2080003

        ''' <summary>
        '''�w�肳�ꂽ�r���[�̍��ڏ�񂪈ُ�ł��B[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewFieldInfoException = 2080004

        ''' <summary>
        '''�r���[SQL�����݂��܂���
        ''' </summary>
        ''' <remarks></remarks>
        ViewSqlNotExisted = 2080005

        ''' <summary>
        '''DBGUI�ŗL���̐ݒ�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        SetDBGUIFailed = 2080006

        ''' <summary>
        '''�w�肳�ꂽ�t�H�[���h�c�̃f�[�^�����݂��܂���B[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        FormIdDataNotExisted = 2080007

        ''' <summary>
        '''�t�B�[���h���̎擾�Ɏ��s���܂���
        ''' </summary>
        ''' <remarks></remarks>
        GetFieldInfoFailed = 2080008

    End Enum

#End Region

#Region " VFAX "

    ''' <summary>
    ''' VFAX �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFAX]

        ''' <summary>
        ''' �܂��Ɓ`��FAX�ɐڑ��ł��܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        MFConnect = 2090001

        ''' <summary>
        ''' �܂��Ɓ`��FAX�ő��M��̏������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MFClearSendFax = 2090002


        ''' <summary>
        ''' �܂��Ɓ`��FAX�ŕۑ���̐ݒ�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MFSaveAs = 2090003

        ''' <summary>
        ''' �܂��Ɓ`��FAX��MFS�ϊ������Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MFPrint = 2090004

        ''' <summary>
        ''' �܂��Ɓ`��FAX�ő��M����̐ݒ�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MFSendToV4 = 2090005

        ''' <summary>
        ''' �܂��Ɓ`��FAX�ő��t��̏������A�܂��͐ݒ�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MFCoverPage = 2090006

        ''' <summary>
        ''' �܂��Ɓ`��FAX�ő��M�f�[�^�̐ݒ�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MFFaxFile = 2090007

        ''' <summary>
        ''' �܂��Ɓ`��FAX�ő��M�����Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MFSendFaxExecute = 2090008

        ''' <summary>
        ''' �܂��Ɓ`��FAX�ō̔Ԃ�����t�ԍ����ő�l�𒴉߂��܂����B
        ''' </summary>
        ''' <remarks></remarks>
        MFReceiptNumberOverflow = 2090009

        ''' <summary>
        ''' �����̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        VFGetDoc = 2090010

        ''' <summary>
        ''' ���M���O�̏������݂Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        VFUpdateLog = 2090011

        ''' <summary>
        ''' �v�����^�̐ݒ�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        VFSetPrinter = 2090012

        ''' <summary>
        ''' ���M����̎擾�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        VFSendData = 2090013

        ''' <summary>
        ''' ���[���̑��M�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        VFSendMail = 2090014

        ''' <summary>
        ''' ���ʖ��擾�f�[�^�̖��m�F�X�e�[�^�X���Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        VFUpdateUnConfirmedStatus = 2090015

    End Enum

#End Region

#Region " VFRM "

    ''' <summary>
    ''' VFRM �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFRM]

        ''' <summary>
        ''' �v���p�e�B�̓��͂ɈႪ����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        PropertyInputError = 2100001

    End Enum

#End Region

#Region " MCAB "

    ''' <summary>
    ''' R@bitFlow TextConverter MCAB �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MCAB]

        ''' <summary>
        ''' �\�����ʗ�O�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        UnkouwnException = 2110001

        ''' <summary>
        ''' ���O�̏o�͐悪�s���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        UnknownLogDevice = 2110002

        ''' <summary>
        ''' '{0}'�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        XMLNotFoundException = 2110003

        ''' <summary>
        ''' CSV�t�@�C���ȊO�̈ڍs�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotCSVTransException = 2110004

        ''' <summary>
        ''' �t�B�[���hID���Z�b�g����Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        UnSetIDFieldException = 2110005

        ''' <summary>
        ''' ����̎��s��ʂ��s���ł��B
        ''' </summary>
        ''' <remarks></remarks>
        UnknownActivateTypeException = 2110006

        ''' <summary>
        ''' ����}�X�^�[�����j�[�N�ł͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonuniqueRestrictionException = 2110007

        ''' <summary>
        ''' �C���X�^���X�̍Đ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ReviveFailedException = 2110008

        ''' <summary>
        ''' ��`�t�@�C�����ύX����Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ChildXMLChangedException = 2110009

        ''' <summary>
        ''' �X���b�h���I���ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ThreadIsAliveException = 2110010

        ''' <summary>
        ''' �ꎞ�f�[�^��IDDOC�����j�[�N�ł͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonuniqueLocalIddocException = 2110011

        ''' <summary>
        ''' �捞�\��GUI�ł͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NonSupportGUIException = 2110012

        ''' <summary>
        ''' �w�肵���ԍ��ɊY������ R@bitFlow �T�[�o�[��������܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        RabitFlowServerNotFoundException = 2110013

    End Enum

#End Region

#Region " ACAB "

    ''' <summary>
    ''' R@bitFlow TextConverter ACAB �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [ACAB]

        ''' <summary>
        ''' �ő啶�����𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        chkFigureError = 2120001

        ''' <summary>
        ''' ���l�ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        chkNumericError = 2120002

        ''' <summary>
        ''' ���l�ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        chkIntegerError = 2120003

        ''' <summary>
        ''' ����/���z�ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        chkMoneyError = 2120004

        ''' <summary>
        ''' ���t�ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ChangeDateError = 2120005

        ''' <summary>
        ''' ���t�t�H�[�}�b�g�`�F�b�N�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateFormatError = 2120006

        ''' <summary>
        ''' �L�����t�`�F�b�N�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateError = 2120007

        ''' <summary>
        ''' ��ʂ̃L�����Z�����I������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        CanceledFormLoadException = 2120008

        ''' <summary>
        ''' ������ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        chkStringError = 2120009

        ''' <summary>
        ''' ���O�C�����Ă���T�[�o�ƈقȂ�T�[�o�ւ̈ڍs�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotIdentificationLoginServerException = 2120010

        ''' <summary>
        ''' �ڍs��ʂ���v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FromDBTypeIdentificationException = 2120011

        ''' <summary>
        ''' �ڍs���T�[�o����v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FromMachineNameIdentificationException = 2120012

        ''' <summary>
        ''' �ڍs���t�@�C��������v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FromFileNameIdentificationException = 2120013

        ''' <summary>
        ''' �ڍs���t�@�C���p�X����v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FromFilePathIdentificationException = 2120014

        ''' <summary>
        ''' �ڍs��T�[�o�[����v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ToServerIdentificationException = 2120015

        ''' <summary>
        ''' �쐬�҂���v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CreateSysBlgIdentificationException = 2120016

        ''' <summary>
        ''' �쐬�҂���v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CreateUserIdentificationException = 2120017

        ''' <summary>
        ''' �ڍs��t�H�[������v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MainToFormIDIdentificationException = 2120018

        ''' <summary>
        ''' �쐬�҂���v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CreateUserNMIdentificationException = 2120019

        ''' <summary>
        ''' �ڍs��t�H�[�����A�f���܂��͌��J�f���ł͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MainFrmIsNotBBSAndWFBBSException = 2120020

    End Enum

#End Region

#Region " MRAC "

    ''' <summary>
    ''' R@bitFlow AccountConveter �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MRAC]

        ''' <summary>
        ''' ���ݒ�l��������Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0001 = 2130001

        ''' <summary>
        ''' �A�g�I�v�V������������Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0002 = 2130002

        ''' <summary>
        ''' �A�g���������ݎ��s���̏ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0003 = 2130003

        ''' <summary>
        ''' �A�g���������b�N����Ă���ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0004 = 2130004

        ''' <summary>
        ''' �f�[�^�x�[�X�̃o�b�N�A�b�v�Ɏ��s�����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0005 = 2130005

        ''' <summary>
        ''' ��Ɨp�g�����U�N�V�����ւ̃f�[�^�R�s�[�Ɏ��s�����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0006 = 2130006

        ''' <summary>
        ''' �ꎞ�f�[�^�̍쐬�Ɏ��s�����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0007 = 2130007

        ''' <summary>
        ''' �f�[�^�̃}�[�W�Ɏ��s�����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0008 = 2130008

        ''' <summary>
        ''' �e�[�u���̃��l�[���Ɏ��s�����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0009 = 2130009

        ''' <summary>
        ''' �l���f�[�^�̃��X�g�A�Ɏ��s�����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0010 = 2130010

        ''' <summary>
        ''' �A�g�t�@�C����������Ȃ������ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0011 = 2130011

        ''' <summary>
        ''' �A�g�t�@�C���Ƀ��R�[�h�����݂��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0012 = 2130012

        ''' <summary>
        ''' �K�{���ڂɒl���ݒ肳��Ă��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0013 = 2130013

        ''' <summary>
        ''' �l���f�[�^�̕������������ݎ��s���̏ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0014 = 2130014

        ''' <summary>
        ''' �l���t���O�Ƃ��Ĉ����Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0015 = 2130015

        ''' <summary>
        ''' ������Ă��Ȃ��R�[�h���w�肳�ꂽ�ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0016 = 2130016

        ''' <summary>
        ''' ��Ӑ���Ɉᔽ�����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0017 = 2130017

        ''' <summary>
        ''' �N���X�C���X�^���X�𕜊������邽�߂̃��R�[�h�����݂��Ȃ������ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0018 = 2130018

        ''' <summary>
        ''' �N���X�C���X�^���X�𕜊������邽�߂̃��R�[�h���������݂���ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0019 = 2130019

        ''' <summary>
        ''' ��ʑg�D���ύX���ꂽ�ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0020 = 2130020

        ''' <summary>
        ''' ���������݂���̂ɑg�D�E�O���[�v��ʂ�ύX���悤�Ƃ����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0021 = 2130021

        ''' <summary>
        ''' �z���ɑg�D�����݂���̂ɁA�g�D�E�O���[�v��ʂ�ύX���悤�Ƃ����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0022 = 2130022

        ''' <summary>
        ''' �����o�^���ɊY�����郊�\�[�X�����݂��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0023 = 2130023

        ''' <summary>
        ''' ��ʑg�D�����݂��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0024 = 2130024

        ''' <summary>
        ''' �o�^���悤�Ƃ��Ă���l���f�[�^�̗L�����Ԃ��d�������ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0025 = 2130025

        ''' <summary>
        ''' �l�ȊO�̖����ȃf�[�^��o�^���悤�Ƃ����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0026 = 2130026

        ''' <summary>
        ''' �l�̖����ȃf�[�^��o�^���悤�Ƃ����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0027 = 2130027

        ''' <summary>
        ''' �l�ȊO�̊����؂�̃f�[�^��o�^���悤�Ƃ����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0028 = 2130028

        ''' <summary>
        ''' �����؂�̌l�f�[�^��o�^���悤�Ƃ����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0029 = 2130029

        ''' <summary>
        ''' ���M���Ǘ��҃��[���A�h���X��������Ȃ������ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0030 = 2130030

        ''' <summary>
        ''' ��M���Ǘ��҃��[���A�h���X��������Ȃ������ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0031 = 2130031

        ''' <summary>
        ''' �ڍאݒ肪������Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0032 = 2130032

        ''' <summary>
        ''' ��ʑg�D��������Ȃ������ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0033 = 2130033

    End Enum

#End Region

#Region " VANC "

    ''' <summary>
    ''' R@bitFlow NotesConveter �v���W�F�N�g�̗�O���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VANC]

        '''' <summary>
        '''' �e���v���[�g�̂��ߌ�ō폜���Ă��������B
        '''' </summary>
        'Tmp = 2140001

        ''' <summary>
        ''' �ő啶�����𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        chkFigureError = 2140001

        ''' <summary>
        ''' ���l�ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        chkNumericError = 2140002

        ''' <summary>
        ''' ���l�ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        chkIntegerError = 2140003

        ''' <summary>
        ''' ����/���z�ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        chkMoneyError = 2140004

        ''' <summary>
        ''' ���t�ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ChangeDateError = 2140005

        ''' <summary>
        ''' ���t�t�H�[�}�b�g�`�F�b�N�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateFormatError = 2140006

        ''' <summary>
        ''' �L�����t�`�F�b�N�Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateError = 2140007

        ''' <summary>
        ''' ��ʂ̃L�����Z�����I������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        CanceledFormLoadException = 2140008

        ''' <summary>
        ''' ������ϊ��Ɏ��s���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        chkStringError = 2140009

        ''' <summary>
        ''' ���O�C�����Ă���T�[�o�ƈقȂ�T�[�o�ւ̈ڍs�͂ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotIdentificationLoginServerException = 2140010

        ''' <summary>
        ''' �ڍs��ʂ���v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FromDBTypeIdentificationException = 2140011

        ''' <summary>
        ''' �ڍs���T�[�o����v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FromMachineNameIdentificationException = 2140012

        ''' <summary>
        ''' �ڍs���t�@�C��������v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FromFileNameIdentificationException = 2140013

        ''' <summary>
        ''' �ڍs���t�@�C���p�X����v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        FromFilePathIdentificationException = 2140014

        ''' <summary>
        ''' �ڍs��T�[�o�[����v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        ToServerIdentificationException = 2140015

        ''' <summary>
        ''' �쐬�҂���v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CreateSysBlgIdentificationException = 2140016

        ''' <summary>
        ''' �쐬�҂���v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CreateUserIdentificationException = 2140017

        ''' <summary>
        ''' �ڍs��t�H�[������v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MainToFormIDIdentificationException = 2140018

        ''' <summary>
        ''' �쐬�҂���v���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CreateUserNMIdentificationException = 2140019

        ''' <summary>
        ''' �ڍs��t�H�[�����A�f���܂��͌��J�f���ł͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MainFrmIsNotBBSAndWFBBSException = 2140020

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        EmptyException = 2140021

        ''' <summary>
        ''' ���[�U�[ID�܂��̓p�X���[�h���Ԉ���Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        UserIdOrPwdError = 2140022

    End Enum

#End Region

End Namespace

