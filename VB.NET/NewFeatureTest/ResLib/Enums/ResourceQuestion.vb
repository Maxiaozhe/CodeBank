Option Compare Binary
Option Explicit On
Option Strict On

Imports System

'
' �m�F
'
Namespace Question
#Region " Common "

    ''' <summary>
    ''' �A�v���P�[�V�������ʂ̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [Common]

        ''' <summary>
        ''' �o�^���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Entry = 5010001

        ''' <summary>
        ''' �폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 5010002

        ''' <summary>
        ''' �I�����܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Quit = 5010003

        ''' <summary>
        ''' �o�^���܂��B��낵���ł����H{0}{0}�w�ύX���e��L���ɂ���ɂ́A�V�X�e���̍ċN�����K�v�ł��x
        ''' </summary>
        ''' <remarks></remarks>
        EntryReboot = 5010004

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 5010005

        ''' <summary>
        ''' �ҏW���̒l�͔j������܂��B�����𒆎~���܂����H
        ''' </summary>
        ''' <remarks></remarks>
        StopProc = 5010006

    End Enum

#End Region

#Region " RFLW "

    ''' <summary>
    ''' R@bitFlow �N���C�A���g�̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFLW]

        ''' <summary>
        '''�o�^���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        SaveCHK = 5020001

        ''' <summary>
        '''�N�����N�ɐݒ肳��Ă��܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        MakeNumYearOverCHK = 5020002

        ''' <summary>
        '''�N�����N�ɐݒ肳��Ă��܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        MakeNumYearUnderCHK = 5020003

        ''' <summary>
        '''�ő哯�񐔂𒴂��Ă��܂��B�����ɑ��M���邱�Ƃ��ł���̂� {0}�� �܂łł��B
        ''' </summary>
        ''' <remarks></remarks>
        FaxCcCountOver = 5020004

    End Enum

#End Region

#Region " NGUI "

    ''' <summary>
    ''' NGUI �v���W�F�N�g�̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [NGUI]

        ''' <summary>
        ''' �e���v���[�g�̂��ߌ�ō폜���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 5030000

    End Enum

#End Region

#Region " VEGG "

    ''' <summary>
    ''' VEGG �v���W�F�N�g�̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VEGG]

        ''' <summary>
        ''' �I�����܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        AppicationEnd = 5040001

        ''' <summary>
        ''' �o�^���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Add = 5040002


        ''' <summary>
        ''' �폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 5040003

        ''' <summary>
        ''' �R�s�[���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Copy = 5040004

        ''' <summary>
        ''' �J�e�S�����폜���܂��B�Ȃ��A�o�^����Ă���t�H�[���́u�J�e�S���Ȃ��v�Ɉړ�����܂��B{0}��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        FormCategoryDelete = 5040005

        ''' <summary>
        ''' �J�e�S�����폜���܂��B�Ȃ��A�o�^����Ă��郋�[�g�́u�J�e�S���Ȃ��v�Ɉړ�����܂��B{0}��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        RouteCategoryDelete = 5040006

        ''' <summary>
        ''' �J�e�S�����폜���܂��B�Ȃ��A�o�^����Ă���r���[�́u�J�e�S���Ȃ��v�Ɉړ�����܂��B{0}��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        ViewCategoryDelete = 5040007

        ''' <summary>
        ''' �J�e�S�����폜���܂��B�Ȃ��A�o�^����Ă��錋�����[�g�́u�J�e�S���Ȃ��v�Ɉړ�����܂��B{0}��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        UnionRouteCategoryDelete = 5040008

        ''' <summary>
        ''' �܂��ARidoc�����v���p�e�B�ݒ�̓o�^���������Ă��܂��񂪁A�I�����Ă���낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        EndPropa = 5040009

        ''' <summary>
        ''' ���X�t�H�[�����������܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        ResClear = 5040010

        ''' <summary>
        ''' �T�u�t�H�[���ɕR�Â��������폜����܂����A��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        SubFormDelete = 5040011

        ''' <summary>
        ''' �œK�����J�n���܂��B{0}�������ɂ���Ă͏����Ɏ��Ԃ�������ꍇ������܂��B{0}��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        ExecuteOptimize = 5040012

        ''' <summary>
        ''' ���ɖ߂��܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        ExecuteUndo = 5040013

        ''' <summary>
        ''' �o�^���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Confirm = 5040014

        ''' <summary>
        ''' �폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Clear = 5040015

        ''' <summary>
        ''' �폜���������͓�x�ƌ��ɖ߂����Ƃ��ł��܂���B{0}�{���ɍ폜���܂����H
        ''' </summary>
        ''' <remarks></remarks>
        ImportantDelete = 5040016


        ''' <summary>
        ''' �ȉ��̓��e�ŕ������������܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Search = 5040017

        ''' <summary>
        ''' �ȉ��̓��e�ŕ������X�V���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Modify = 5040018

        ''' <summary>
        ''' �ȉ��̓��e��Ridoc�𕜋����܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        RidocFailedCheck = 5040019

        ''' <summary>
        '''���ݕ\���E�ҏW����Ă���r���[���e�������܂����A��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        NotSaveData = 5040020

        ''' <summary>
        '''�I������Ă��鍀�ڏ�񓙂͂��ׂč폜����܂�����낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        DelAllData = 5040021

        ''' <summary>
        '''�\���`�����ꗗ�ɐݒ肷��ƁA�ݒ肵�Ă���O���[�v���̏�񂪏�������܂�����낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        DelGrpInfo = 5040022

        ''' <summary>
        '''�o�^��́A�r���[�^�C�v�̕ύX�͂ł��Ȃ��Ȃ�܂��B
        ''' </summary>
        ''' <remarks></remarks>
        NotModify = 5040023

        ''' <summary>
        '''�J�e�S�����폜���܂��B�Ȃ��A�o�^����Ă���r���[�́u�J�e�S���Ȃ��v�Ɉړ�����܂��B{0}��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        DelCategory = 5040024

        ''' <summary>
        '''�{�Ԋ��́u�����t�H�[�����|�J�e�S���Ȃ��v�ɃR�s�[���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        SameCategoryCopy = 5040025

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 5040026
    End Enum

#End Region

#Region " VFRM "

    ''' <summary>
    ''' VFRM �v���W�F�N�g�̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFRM]

        ''' <summary>
        '''�I�����܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Close = 5050001

        ''' <summary>
        '''{0}�͕ύX����Ă��܂��B�ۑ����܂����H
        ''' </summary>
        ''' <remarks></remarks>
        CancleClose = 5050002

        ''' <summary>
        '''{0}�̕ύX��ۑ����܂����H
        ''' </summary>
        ''' <remarks></remarks>
        Preview = 5050003

        ''' <summary>
        '''�o�^���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Save = 5050004

    End Enum

#End Region

#Region " VGUI "

    ''' <summary>
    ''' VGUI �v���W�F�N�g�̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VGUI]

        ''' <summary>
        ''' �o�^���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        AreYouEntry = 5060001

        ''' <summary>
        ''' �T�u�t�H�[����ύX�����ꍇ�A�ݒ肳��Ă����񂪃N���A����܂�����낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        SetInformationClear = 5060002

        ''' <summary>
        ''' �Q�ƃr���[��ύX�����ꍇ�A����܂ł̐ݒ���e�̓N���A����܂�����낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        ReferenceViewResetOkOrNot = 5060003

        ''' <summary>
        ''' ����܂ł̐ݒ���e���N���A����܂�����낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        ClearOkOrNot = 5060004

        ''' <summary>
        ''' ���Ƀf�[�^���݂���ꍇ�A�����I������Ă���f�[�^�̈ꕔ���������܂����H
        ''' </summary>
        ''' <remarks></remarks>
        DeleteExistedData = 5060005

        ''' <summary>
        ''' ���ݕ\���E�ҏW����Ă�����e�������܂����A��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        FormReset = 5060006

        ''' <summary>
        ''' �폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        AreYouDelete = 5060007

    End Enum

#End Region

#Region " VJNJ "

    ''' <summary>
    ''' VJNJ �v���W�F�N�g�̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VJNJ]

        ''' <summary>
        ''' �ǉ����܂��B��낵���ł����H
        ''' </summary>
        AddNewConfirm = 5070001

        ''' <summary>
        ''' �C�����܂��B��낵���ł����H
        ''' </summary>
        ModifyConfirm = 5070002

        ''' <summary>
        ''' �폜���܂��B��낵���ł����H
        ''' </summary>
        RemoveConfirm = 5070003

        ''' <summary>
        ''' �o�^���܂��B��낵���ł����H
        ''' </summary>
        EntryConfirm = 5070004

        ''' <summary>
        ''' �폜����{0}�͓�x�ƌ��ɖ߂����Ƃ��ł��܂���B�{���ɍ폜���܂����H
        ''' </summary>
        WarningRemoveConirm = 5070005

        ''' <summary>
        ''' �\�������� 0 �Ɏw�肷��ƊY�����邷�ׂĂ�{0}��\�����܂��B
        ''' ���̏����ɂ͎��Ԃ�������ꍇ������܂��B
        ''' �������J�n���܂����H
        ''' 
        ''' �Y������{0}���������݂���ꍇ�́A�����������w�肷�邩�\����������͂��Ă��������B
        ''' </summary>
        SearchConfirm = 5070006

        ''' <summary>
        ''' �I�����܂��B��낵���ł����H
        ''' </summary>
        TerminationConfirm = 5070007

        ''' <summary>
        ''' ���b�N���������܂��B��낵���ł����H
        ''' </summary>
        UnLockTerminationConfirm = 5070008

        ''' <summary>
        '''���ݕҏW����Ă�����e�������܂����A��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        NotSaveData = 5070009

    End Enum

#End Region

#Region " VMNU "

    ''' <summary>
    ''' VMNU �v���W�F�N�g�̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VMNU]
        ''' <summary>
        ''' �o�^���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Entry = 5080001

        ''' <summary>
        ''' �폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 5080002

        ''' <summary>
        ''' �I�����܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Quit = 5080003

        ''' <summary>
        ''' �o�^���܂��B��낵���ł����H{0}{0}�w�ύX���e��L���ɂ���ɂ́A�V�X�e���̍ċN�����K�v�ł��x
        ''' </summary>
        ''' <remarks></remarks>
        EntryReboot = 5080004

        ''' <summary>
        ''' �d�񔭍s�t�@�C������荞�݂܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        UploadDenpo = 5080005

        ''' <summary>
        ''' ���}�X�^�[�t�@�C������荞�݂܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        UploadHall = 5080006

        ''' <summary>
        ''' �\�����Ă���N�x�̋x���E�j�������ׂč폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        RemoveAllHoliday = 5080007

        ''' <summary>
        ''' �����t�@�C�����쐬�쐬���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        CreateDictionary = 5080008

    End Enum

#End Region

#Region " VRTE "

    ''' <summary>
    ''' VRTE �v���W�F�N�g�̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRTE]

        ''' <summary>
        ''' �I�����܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        AppicationEnd = 5090001

        ''' <summary>
        ''' ���[�g���폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        routeQ001 = 5090002

        ''' <summary>
        ''' ����������폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        routeQ002 = 5090003

        ''' <summary>
        ''' �o�^���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        routeQ003 = 5090004

        ''' <summary>
        ''' �폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        routeQ004 = 5090005

        ''' <summary>
        ''' �ꗗ�ɕ\������Ă��邷�ׂĂ̑g�D�E�O���[�v���ړ����܂��B{0}�������Ԃ͌����ɔ�Ⴕ�܂��B����ł����s���܂����H
        ''' </summary>
        ''' <remarks></remarks>
        routeQ005 = 5090006

    End Enum

#End Region

#Region " VRUN "

    ''' <summary>
    ''' VRUN �v���W�F�N�g�̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRUN]

        ''' <summary>
        ''' �I�����܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        AppicationEnd = 5100001

        ''' <summary>
        ''' ���[�g���폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        routeQ001 = 5100002

        ''' <summary>
        ''' ����������폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        routeQ002 = 5100003

        ''' <summary>
        ''' �o�^���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        routeQ003 = 5100004

        ''' <summary>
        ''' �폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        routeQ004 = 5100005

        ''' <summary>
        ''' �o�^���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Add = 5100006

        ''' <summary>
        ''' �폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 5100007

        ''' <summary>
        ''' �J�e�S�����폜���܂��B�Ȃ��A�o�^����Ă���t�H�[���́u�J�e�S���Ȃ��v�Ɉړ�����܂��B{0}��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        FormCategoryDelete = 5100008

        ''' <summary>
        ''' �J�e�S�����폜���܂��B�Ȃ��A�o�^����Ă��郋�[�g�́u�J�e�S���Ȃ��v�Ɉړ�����܂��B{0}��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        RouteCategoryDelete = 5100009

        ''' <summary>
        ''' �܂��ARidoc�����v���p�e�B�ݒ�̓o�^���������Ă��܂��񂪁A�I�����Ă���낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        EndPropa = 5100010

        ''' <summary>
        ''' �o�^���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Confirm = 5100011

        ''' <summary>
        ''' �폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Clear = 5100012

    End Enum

#End Region

#Region " VFAX "

    ''' <summary>
    ''' VFAX �v���W�F�N�g�̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFAX]

        ''' <summary>
        ''' �������̃f�[�^�����݂��܂��B�I�����Ă�낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        ProcInClose = 5110001

        ''' <summary>
        ''' �������̃f�[�^�����݂��܂��B�I�����Ă�낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        ProcInClose2 = 5110002

    End Enum

#End Region

#Region " VALP "

    ''' <summary>
    ''' VALP �v���W�F�N�g�̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VALP]

        ''' <summary>
        ''' �o�^���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Msg0001 = 5120001

    End Enum

#End Region

#Region " RFGC "

    ''' <summary>
    ''' R@bitFlow GuiComponents �v���W�F�N�g�̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFGC]

        ''' <summary>
        ''' ���M���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        IsSendConfirm = 5130001

    End Enum

#End Region

#Region " ACAB "

    ''' <summary>
    ''' ACAB �v���W�F�N�g�̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [ACAB]

        ''' <summary>
        '''���O�\���p�L�[���ڂ��ݒ肳��Ă��܂��񂪁A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        NotesKeyNoNotSelected = 5140001

        ''' <summary>
        '''��`�t�@�C����Ǎ��݂܂����H 
        ''' </summary>
        ''' <remarks></remarks>
        ReadMappingXML = 5140002

        ''' <summary>
        '''�ꎞ�f�[�^�쐬�����s���܂��B{0}{0}�ȑO�쐬�̃f�[�^�͏�������܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        MakeLocalData = 5140003

        ''' <summary>
        '''�I�����ꂽ�t�H�[���̃f�[�^�������擾���܂��B{0}�����Ɏ��Ԃ�������ꍇ������܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        GetNotesDataCount = 5140004

        ''' <summary>
        '''�I�����ꂽ�t�@�C���̃f�[�^�������擾���܂��B{0}�����Ɏ��Ԃ�������ꍇ������܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        GetCsvDataCount = 5140005

        ''' <summary>
        '''����}�X�^���X�V���܂��B��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        MakeSeiyakuData = 5140006

        ''' <summary>
        '''�I�����܂��B��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        EndMessage = 5140007

        ''' <summary>
        '''�A�b�v���[�h���J�n���܂��B��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        StartUpLoad = 5140008

        ''' <summary>
        '''�ۑ����Ă��Ȃ��ꍇ�A���ݕҏW���̏��͎����܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        IsErase = 5140009

        ''' <summary>
        '''���݂̐ݒ���̓N���A����܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        CoutionCnt = 5140010

        ''' <summary>
        '''�L���Ȉꎞ�f�[�^���쐬����Ă��܂��B{0}�f�[�^�A�b�v���[�h��ʂ��J���܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        AUOpenUpLoadWindow = 5140011

        ''' <summary>
        '''�ꎞ�f�[�^�͐���ɍ쐬����܂����B{0}{0} �ڍs���ʃ��|�[�g��ۑ����܂����H 
        ''' </summary>
        ''' <remarks></remarks>
        CreateLocalDataComplete = 5140012

        ''' <summary>
        '''�ꎞ�f�[�^���쐬���܂��B{0}{0}�ڍs���ʏڍ׃��O���L�^���܂����H 
        ''' </summary>
        ''' <remarks></remarks>
        WriteConvertLog = 5140013

        ''' <summary>
        '''�R�s�[���J�n���܂��B��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        CopyStart = 5140014

        ''' <summary>
        '''�ꎞ�f�[�^�쐬�𒆒f���܂��B��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        AbortCreate = 5140015

        ''' <summary>
        '''�e�L�X�g�C���q�u{0}�v�̏ꍇ�A{1}�������f�[�^���Ǎ��߂Ȃ��ꍇ������܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        NonQualifier = 5140016

        ''' <summary>
        ''' �A�b�v���[�h���J�n���܂��B{0}{0}�ڍs���ʏڍ׃��O���L�^���܂����H
        ''' </summary>
        ''' <remarks></remarks>
        WriteUploadLog = 5140017

    End Enum

#End Region

#Region " VRAC "

    ''' <summary>
    ''' R@bitFlow AccountConverter �̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRAC]

        ''' <summary>
        ''' �A�g�����J�n�̊m�F���b�Z�[�W
        ''' </summary>
        Msg0001 = 5160001

        ''' <summary>
        ''' �l���f�[�^�����J�n�̊m�F���b�Z�[�W
        ''' </summary>
        Msg0002 = 5160002

        ''' <summary>
        ''' �I���m�F���b�Z�[�W
        ''' </summary>
        Msg0003 = 5160003

        ''' <summary>
        ''' �ڍאݒ�̓o�^�m�F���b�Z�[�W�B
        ''' </summary>
        Msg0004 = 5160004

        ''' <summary>
        ''' �ړ���t�H���_�����͂���Ă��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0005 = 5160005

    End Enum

#End Region

#Region " VANC "

    ''' <summary>
    ''' R@bitFlow NotesConveter �̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VANC]

        ''' <summary>
        '''���O�\���p�L�[���ڂ��ݒ肳��Ă��܂��񂪁A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        NotesKeyNoNotSelected = 5180001

        ''' <summary>
        '''��`�t�@�C����Ǎ��݂܂����H 
        ''' </summary>
        ''' <remarks></remarks>
        ReadMappingXML = 5180002

        ''' <summary>
        '''�ꎞ�f�[�^�쐬�����s���܂��B{0}{0}�ȑO�쐬�̃f�[�^�͏�������܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        MakeLocalData = 5180003

        ''' <summary>
        '''�I�����ꂽ�t�H�[���̃f�[�^�������擾���܂��B{0}�����Ɏ��Ԃ�������ꍇ������܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        GetNotesDataCount = 5180004

        ''' <summary>
        '''�I�����ꂽ�t�@�C���̃f�[�^�������擾���܂��B{0}�����Ɏ��Ԃ�������ꍇ������܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        GetCsvDataCount = 5180005

        ''' <summary>
        '''����}�X�^���X�V���܂��B��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        MakeSeiyakuData = 5180006

        ''' <summary>
        '''�I�����܂��B��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        EndMessage = 5180007

        ''' <summary>
        '''�A�b�v���[�h���J�n���܂��B��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        StartUpLoad = 5180008

        ''' <summary>
        '''�ۑ����Ă��Ȃ��ꍇ�A���ݕҏW���̏��͎����܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        IsErase = 5180009

        ''' <summary>
        '''���݂̐ݒ���̓N���A����܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        CoutionCnt = 5180010

        ''' <summary>
        '''�L���Ȉꎞ�f�[�^���쐬����Ă��܂��B{0}�f�[�^�A�b�v���[�h��ʂ��J���܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        AUOpenUpLoadWindow = 5180011

        ''' <summary>
        '''�ꎞ�f�[�^�͐���ɍ쐬����܂����B{0}{0} �ڍs���ʃ��|�[�g��ۑ����܂����H 
        ''' </summary>
        ''' <remarks></remarks>
        CreateLocalDataComplete = 5180012

        ''' <summary>
        '''�ꎞ�f�[�^���쐬���܂��B{0}{0}�ڍs���ʏڍ׃��O���L�^���܂����H 
        ''' </summary>
        ''' <remarks></remarks>
        WriteConvertLog = 5180013

        ''' <summary>
        '''�R�s�[���J�n���܂��B��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        CopyStart = 5180014

        ''' <summary>
        '''�ꎞ�f�[�^�쐬�𒆒f���܂��B��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        AbortCreate = 5180015

        ''' <summary>
        '''�e�L�X�g�C���q�u{0}�v�̏ꍇ�A{1}�������f�[�^���Ǎ��߂Ȃ��ꍇ������܂����A��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        NonQualifier = 5180016

        ''' <summary>
        ''' �A�b�v���[�h���J�n���܂��B{0}{0}�ڍs���ʏڍ׃��O���L�^���܂����H
        ''' </summary>
        ''' <remarks></remarks>
        WriteUploadLog = 5180017

        ''' <summary>
        ''' ���̃f�[�^���폜���܂����H
        ''' </summary>
        ''' <remarks></remarks>
        DeleteAllOldData = 5180018

        ''' <summary>
        ''' ���[�U�[�̃}�b�s���O�f�[�^�����[�J���f�[�^�x�[�X�ɓo�^���܂��B{0}��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        QuestionBeforeUserDataInsert = 5180019

        ''' <summary>
        '''�A�b�v���[�h�𒆒f���܂��B��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        AbortUpload = 5180020

        ''' <summary>
        '''�ݒ���e���m�肵�܂��B��낵���ł����H 
        ''' </summary>
        ''' <remarks></remarks>
        IsSave = 5180021
    End Enum

#End Region

#Region " VAGP "

    ''' <summary>
    ''' �A�v���P�[�V�������ʂ̊m�F���b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VAGP]

        ''' <summary>
        ''' �ύX���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Modify = 5190001

        ''' <summary>
        ''' �폜���܂��B��낵���ł����H
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 5190002

    End Enum

#End Region
End Namespace

