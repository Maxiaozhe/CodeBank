Option Compare Binary
Option Explicit On
Option Strict On

Imports System
'
' ���
'
Namespace Information
#Region " Common "

    ''' <summary>
    ''' �A�v���P�[�V�������ʂ̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [Common]

        ''' <summary>
        ''' �������I�����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ProcessComplete = 4010001

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks>��O�̓��e�����̂܂ܕ\������ꍇ�Ɏg�p���܂��B</remarks>
        ExceptionMessage = 4010002

    End Enum

#End Region

#Region " RFLW "

    ''' <summary>
    ''' R@bitFlow �N���C�A���g�̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFLW]
        ''' <summary>
        '''�p�X���[�h��ύX���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InfoChangePass = 4020001

        ''' <summary>
        '''�ꊇ{0}���������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        EndAllAccept = 4020002

        ''' <summary>
        '''�f�t�H���g������ύX���܂����B{0}����̃r���[��ʂւ̃��O�C�������ݒ肪�L���ɂȂ�܂��B
        ''' </summary>
        ''' <remarks></remarks>
        DefSysBlgCheEnd = 4020003

        ''' <summary>
        '''�ő哯�񐔂𒴂��Ă��܂��B�����ɑ��M���邱�Ƃ��ł���̂� {0}�� �܂łł��B
        ''' </summary>
        ''' <remarks></remarks>
        FaxCcCountOver = 4020004

        ''' <summary>
        '''�����쐬�҂�I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectSharedUser = 4020005

        ''' <summary>
        '''�I�����ꂽ�����ɂ́A���������Ă��镶�������݂��܂���B{0}�v���r���[�\�����邱�Ƃ��ł��܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotPrint = 4020006

        ''' <summary>
        '''�I�����ꂽ�����ɁA���������Ă��Ȃ��������܂܂�Ă��܂��B{0}������Ă��Ȃ������̃v���r���[�͕\������܂���B
        ''' </summary>
        ''' <remarks></remarks>
        CanNotPreview = 4020007

        ''' <summary>
        ''' ���[�g��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectionRoute = 4020008

    End Enum

#End Region

#Region " NGUI "

    ''' <summary>
    ''' NGUI �v���W�F�N�g�̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [NGUI]

        ''' <summary>
        ''' ���Ԃ͂���܂���B
        ''' </summary>
        ''' <remarks></remarks>
        MissingNumber = 4030001

    End Enum

#End Region

#Region " VEGG "

    ''' <summary>
    ''' VEGG �v���W�F�N�g�̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VEGG]

        ''' <summary>
        ''' �o�^������ɏI�����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        Update = 4040001


        ''' <summary>
        ''' �폜������ɏI�����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 4040002

        ''' <summary>
        ''' ���ݑg�D���Ғ��ł��B���[�g�̕ҏW�ł��܂���(���e�̎Q�Ƃ̂݉\�ł�)�B
        ''' </summary>
        ''' <remarks></remarks>
        OnTheWayReOrganization = 4040003

        ''' <summary>
        ''' �o�^������ɏI�����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        Entry = 4040004


        ''' <summary>
        ''' Ridoc�A�g�̓o�^������ɏI�����܂����B{0}�^�p�ݒ�̓o�^�{�^���������ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        Entry2 = 4040005

        ''' <summary>
        ''' �R�s�[�����t�H�[���̂f�t�h�R���|�[�l���g�̑����ݒ肪�u���ݒ�v�ƂȂ�܂��B{0}�t�H�[���G�f�B�^���ݒ�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        GUIConIsNoSetMessage = 4040006

        ''' <summary>
        ''' �����r���[�̓R�s�[�ł��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewNotCopy = 4040007

        ''' <summary>
        '''�R�s�[���������܂����B�R�s�[��ŃJ�e�S���̈ړ����s���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        MoveCategory = 4040008
        ''' <summary>
        ''' �t�@�C���捞�݂������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ImportFinashed = 4040009
        ''' <summary>
        ''' �t�@�C���o�͂������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        ExportFinashed = 4040010
    End Enum

#End Region

#Region " VFRM "

    ''' <summary>
    ''' VFRM �v���W�F�N�g�̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFRM]

        ''' <summary>
        ''' �e���v���[�g�̂��ߌ�ō폜���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 4050000

    End Enum

#End Region

#Region " VGUI "

    ''' <summary>
    ''' VGUI �v���W�F�N�g�̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VGUI]

        ''' <summary>
        ''' �t�H�[�����ڂ��I������Ă��Ȃ����A�I������Ă��鍀�ڂ��I��s�ɂȂ��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectFormField = 4060001

        ''' <summary>
        ''' �w�肳�ꂽ�t�H�[�����ڂ��t�H�[���ɑ��݂��Ă��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        NotExistsFormField = 4060002

        ''' <summary>
        ''' �J�n������I�����܂ł͈̔͂����Ԃ̍ő�͈͂𒴂��Ă��܂��B
        ''' </summary>
        ''' <remarks></remarks>
        OverMaxRangeItem = 4060003

        ''' <summary>
        ''' �ݒ��o�^���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        RegistOK = 4060004

        ''' <summary>
        ''' �v�Z���̃`�F�b�N�����튮�����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        ExpressCheckOK = 4060005

    End Enum

#End Region

#Region " VJNJ "

    ''' <summary>
    ''' VJNJ �v���W�F�N�g�̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VJNJ]

        ''' <summary>
        ''' �L���J�n���t���ύX����܂����B
        ''' 
        ''' �V�����o�^����L���J�n���t�ȑO�ɐݒ肳��Ă��鉺�ʂ̑g�D�E�O���[�v����сA�g�D�E�O���[�v�ɑ�����
        ''' �����̗L���J�n���t�́A�V�������t�ōX�V����܂��B
        ''' �ύX�����L���J�n���t���L���������t�ȍ~�ƂȂ�g�D�E�O���[�v����я����͍폜����܂��B
        ''' �폜���ꂽ�g�D�E�O���[�v����я����́A���ɖ߂����Ƃ��ł��܂���B
        ''' </summary>
        GroupMsg0001 = 4070001

        ''' <summary>
        ''' �L���������t���ύX����܂����B
        ''' 
        ''' �V�����o�^����L���������t�ȍ~�ɐݒ肳��Ă��鉺�ʂ̑g�D�E�O���[�v����сA�g�D�E�O���[�v�ɑ�����
        ''' �����̗L���������t�́A�V�������t�ōX�V����܂��B
        ''' �ύX�����L���������t���L���J�n���t�ȑO�ƂȂ�g�D�E�O���[�v����я����͍폜����܂��B
        ''' �폜���ꂽ�g�D�E�O���[�v����я����́A���ɖ߂����Ƃ��ł��܂���B
        ''' </summary>
        GroupMsg0002 = 4070002

        ''' <summary>
        ''' �g�D�E�O���[�v���A�����A�p�������ύX����܂����B
        ''' ���̏ꍇ�A���ʑg�D�E�O���[�v�̖��̂��ύX���邽�߁A�����Ɏ��Ԃ��|����܂��B
        ''' </summary>
        GroupMsg0003 = 4070003

        ''' <summary>
        ''' ���p�J�n���t���ύX����܂����B
        ''' 
        ''' �l�̗��p�J�n���t��ύX�����ꍇ�A���ɓo�^����Ă��鏊���̗L���J�n���t�́A
        ''' �l�̗��p�J�n���t�ŕύX����܂��B
        ''' �ύX�̑ΏۂƂȂ鏊���́A�V�����ύX����l�̗L���J�n���t�ȑO�̏����ł��B
        ''' �ύX�����L���J�n���t���L���������t�ȍ~�ƂȂ鏊���͍폜����܂��B
        ''' �폜���ꂽ�����́A���ɖ߂����Ƃ��ł��܂���B
        ''' </summary>
        PersonMsg0001 = 4071001

        ''' <summary>
        ''' ���p�I�����t���ύX����܂����B
        ''' 
        ''' �l�̗��p�I�����t��ύX�����ꍇ�A���ɓo�^����Ă��鏊���̗L���������t�A
        ''' �l�̗��p�I�����t�ŕύX����܂��B
        ''' �ύX�̑ΏۂƂȂ鏊���́A�V�����ύX����l�̗L���������t�ȍ~�̏����ł��B
        ''' �ύX�����L���������t���L���J�n���t�ȑO�ƂȂ鏊���͍폜����܂��B
        ''' �폜���ꂽ�����́A���ɖ߂����Ƃ��ł��܂���B
        ''' </summary>
        PersonMsg0002 = 4071002

    End Enum

#End Region

#Region " VMNU "

    ''' <summary>
    ''' VMNU �v���W�F�N�g�̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VMNU]

        ''' <summary>
        ''' �o�^����������ɏI�����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        AddDataOk = 4080001

        ''' <summary>
        ''' �X�V����������ɏI�����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        UpdDataOk = 4080002

        ''' <summary>
        ''' �폜����������ɏI�����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DelDataOk = 4080003

        ''' <summary>
        ''' �Ώۃf�[�^���ꌏ������܂���ł����B
        ''' </summary>
        ''' <remarks></remarks>
        NotData = 4080004


        ''' <summary>
        ''' ��荞�ݏ������������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DenpoOK = 4080005

        ''' <summary>
        ''' �Ј���I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectionUser = 4080006

        ''' <summary>
        ''' ���[�g��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectionRoute = 4080007

        ''' <summary>
        ''' �g�D�E��E�܂��̓O���[�v��I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectioGroup = 4080008

        ''' <summary>
        ''' �����t�@�C�����쐬���܂����B
        ''' �쐬���������t�@�C����L���ɂ���ꍇ�́A�S�������T�[�r�X���ċN�����Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        CreatedDictionary = 4080009

        ''' <summary>
        ''' CSV�t�@�C���̏o�͂��������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        OutputCsvCompleted = 4080010

        ''' <summary>
        ''' CSV�t�@�C���̎捞���������܂����B
        ''' </summary>
        ''' <remarks></remarks>
        InputCsvCompleted = 4080011

    End Enum

#End Region

#Region " VRTE "

    ''' <summary>
    ''' VRTE �v���W�F�N�g�̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRTE]

        ''' <summary>
        ''' ���̃��[�g�͐������������Ȃ��Ă��܂����ׁA�g�p�ł��܂���B{0} ���[�g���č쐬���ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeI001 = 4090001

        ''' <summary>
        ''' ���[�g�`�F�b�N���I�����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        routeI002 = 4090002

        ''' <summary>
        ''' �폜�Ώۂ�I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeI003 = 4090003

        ''' <summary>
        ''' �I�����ꂽ�g�D�ɎЈ������݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeI004 = 4090004

        ''' <summary>
        ''' �폜���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        routeI005 = 4090005

        ''' <summary>
        ''' �I�����ꂽ�g�D�ɎЈ������݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeI006 = 4090006

    End Enum

#End Region

#Region " VRUN "

    ''' <summary>
    ''' VRUN �v���W�F�N�g�̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRUN]

        ''' <summary>
        ''' �I�����ꂽ�g�D�ɎЈ������݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeI001 = 4100001

        ''' <summary>
        ''' ���[�g�`�F�b�N���I�����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        routeI002 = 4100002

        ''' <summary>
        ''' �폜�Ώۂ�I�����ĉ������B
        ''' </summary>
        ''' <remarks></remarks>
        routeI003 = 4100003

        ''' <summary>
        ''' �I��Ώۂɑg�D�E�O���[�v�����݂��܂���B
        ''' </summary>
        ''' <remarks></remarks>
        routeI004 = 4100004

        ''' <summary>
        ''' �폜���܂����B
        ''' </summary>
        ''' <remarks></remarks>
        routeI005 = 4100005

        ''' <summary>
        ''' �o�^������ɏI�����܂����B
        ''' </summary>
        ''' <remarks>
        '''�t�H�[��/���[�g�����f�[�^�E�t�H�[���ڍ׊Ǘ��f�[�^����I����
        '''</remarks>
        Update = 4100006

        ''' <summary>
        ''' �폜������ɏI�����܂����B
        ''' </summary>
        ''' <remarks>
        '''�t�H�[�����E���[�g�f�[�^�폜����I����
        '''</remarks>
        Delete = 4100007

        ''' <summary>
        ''' ���ݑg�D���Ғ��ł��B���[�g�̕ҏW�ł��܂���(���e�̎Q�Ƃ̂݉\�ł�)�B
        ''' </summary>
        ''' <remarks>
        '''�t�H�[�����E���[�g�f�[�^�폜����I����
        '''</remarks>
        OnTheWayReOrganization = 4100008

        ''' <summary>
        ''' �o�^������ɏI�����܂����B
        ''' </summary>
        ''' <remarks>
        '''�����v���p�e�B�ݒ�o�^����I����
        '''</remarks>
        Entry = 4100009

        ''' <summary>
        ''' Ridoc�A�g�̓o�^������ɏI�����܂����B{0}�^�p�ݒ�̓o�^�{�^���������ĉ������B
        ''' </summary>
        ''' <remarks>
        '''Ridoc�A�g�̓o�^�I����
        '''</remarks>
        Entry2 = 4100010

        ''' <summary>
        ''' �I��Ώۂɑg�D�E�O���[�v�����݂��܂���B
        ''' </summary>
        ''' <remarks>
        '''Ridoc�A�g�̓o�^�I����
        '''</remarks>
        RUN_I004 = 4100011

    End Enum

#End Region

#Region " VFAX "

    ''' <summary>
    ''' VFAX �v���W�F�N�g�̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFAX]

        ''' <summary>
        ''' �e���v���[�g�̂��ߌ�ō폜���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 4110000

    End Enum

#End Region

#Region " VALP "

    ''' <summary>
    ''' VALP �v���W�F�N�g�̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VALP]

        ''' <summary>
        ''' �e���v���[�g�̂��ߌ�ō폜���Ă��������B
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 4120000

    End Enum

#End Region

#Region " ACAB "

    ''' <summary>
    ''' ACAB �v���W�F�N�g�̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [ACAB]

        ''' <summary>
        '''�t�H�[����`�t�@�C���͐���ɕۑ�����܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        WriteXMLComplete = 4140001

        ''' <summary>
        '''�f�[�^�A�b�v���[�h��`�t�@�C���͐���ɕۑ�����܂����B{0}�ꎞ�f�[�^�쐬�����s���ĉ������B 
        ''' </summary>
        ''' <remarks></remarks>
        WriteDataXMLComplete = 4140002

        ''' <summary>
        '''�A�b�v���[�h���I�����܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        UploadComplete = 4140003

        ''' <summary>
        '''����}�X�^�ɂ͈ꌏ���f�[�^�����݂��܂���B 
        ''' </summary>
        ''' <remarks></remarks>
        SelectNoSeiyakuData = 4140004

        ''' <summary>
        '''����}�X�^�̍X�V�����s���܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        CreateSeiyakuDataErr = 4140005

        ''' <summary>
        '''����}�X�^�̍X�V���I�����܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        CreateSeiyakuDataComplete = 4140006

        ''' <summary>
        '''���������f����܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        AbortUpdate = 4140007

        ''' <summary>
        '''�ꎞ�f�[�^�Ɛݒ�t�@�C���̓��e���قȂ�܂��B{0}�ꎞ�f�[�^�쐬�����蒼���Ă��������B 
        ''' </summary>
        ''' <remarks></remarks>
        ChengedMappingFiles = 4140008

        ''' <summary>
        '''�ꎞ�f�[�^�����݂��Ȃ����߁A�A�b�v���[�h�ł��܂���B 
        ''' </summary>
        ''' <remarks></remarks>
        NothingTempData = 4140009

        ''' <summary>
        '''�ڍs��t�H�[�����Ăяo��GUI�����݂��܂���B 
        ''' </summary>
        ''' <remarks></remarks>
        NothingCallSubFrmGui = 4140010

        ''' <summary>
        '''�ꎞ�f�[�^�쐬�͒��f����܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        AbortCreate = 4140011

        ''' <summary>
        '''�ꎞ�f�[�^�쐬�͏I�����Ă��܂��B 
        ''' </summary>
        ''' <remarks></remarks>
        AlreadyCreateed = 4140012

        ''' <summary>
        '''�t�H�[���̃R�s�[���I�����܂����B{0}�V�t�H�[���h�c�́u{1}�v�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        CopyEnd = 4140013

    End Enum

#End Region

#Region " VRAC "

    ''' <summary>
    ''' R@bitFlow AccountConverter �̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRAC]

        ''' <summary>
        ''' �ڍאݒ肪���s����Ă��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0001 = 4160001

        ''' <summary>
        ''' �A�g���������s���̂��ߊJ�n�ł��Ȃ����b�Z�[�W�B
        ''' </summary>
        Msg0002 = 4160002

        ''' <summary>
        ''' �A�g���������b�N����Ă��邽�ߊJ�n�ł��Ȃ����b�Z�[�W�B
        ''' </summary>
        Msg0003 = 4160003

        ''' <summary>
        ''' �A�g�����̐������������b�Z�[�W�B
        ''' </summary>
        Msg0004 = 4160004

        ''' <summary>
        ''' �A�g�����̎��s���������b�Z�[�W�B
        ''' </summary>
        Msg0005 = 4160005

        ''' <summary>
        ''' �l���f�[�^�̕����������������b�Z�[�W�B
        ''' </summary>
        Msg0006 = 4160006

        ''' <summary>
        ''' �l���f�[�^�̕����Ɏ��s�����ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0007 = 4160007

        ''' <summary>
        ''' �l���f�[�^�̕������������s���̂��ߊJ�n�ł��Ȃ����b�Z�[�W�B
        ''' </summary>
        Msg0008 = 4160008

        ''' <summary>
        ''' ���O�C�����[�U�[�ɂ��捞���J�n���ꂽ���b�Z�[�W�B
        ''' </summary>
        Msg0009 = 4160009

        ''' <summary>
        ''' �ڍאݒ肪�s���Ă��Ȃ��ꍇ�̃��b�Z�[�W�B
        ''' </summary>
        Msg0010 = 4160010

    End Enum

#End Region

#Region " MRAC "

    ''' <summary>
    ''' R@bitFlow AccountConverter �̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MRAC]

        ''' <summary>
        ''' �o�b�N�A�b�v�̊J�n���b�Z�[�W
        ''' </summary>
        Msg0001 = 4170001

        ''' <summary>
        ''' �o�b�N�A�b�v�̏I�����b�Z�[�W
        ''' </summary>
        Msg0002 = 4170002

        ''' <summary>
        ''' ���[�N�e�[�u���փR�s�[�J�n�̃��b�Z�[�W
        ''' </summary>
        Msg0003 = 4170003

        ''' <summary>
        ''' ���[�N�e�[�u���փR�s�[�I���̃��b�Z�[�W
        ''' </summary>
        Msg0004 = 4170004

        ''' <summary>
        ''' �ꎞ�f�[�^�쐬�J�n�̃��b�Z�[�W
        ''' </summary>
        Msg0005 = 4170005

        ''' <summary>
        ''' �ꎞ�f�[�^�쐬�I���̃��b�Z�[�W
        ''' </summary>
        Msg0006 = 4170006

        ''' <summary>
        ''' �}�[�W�J�n�̃��b�Z�[�W
        ''' </summary>
        Msg0007 = 4170007

        ''' <summary>
        ''' �}�[�W�I���̃��b�Z�[�W
        ''' </summary>
        Msg0008 = 4170008

        ''' <summary>
        ''' ���l�[���J�n�̃��b�Z�[�W
        ''' </summary>
        Msg0009 = 4170009

        ''' <summary>
        ''' ���l�[���I���̃��b�Z�[�W
        ''' </summary>
        Msg0010 = 4170010

        ''' <summary>
        ''' �A�[�J�C�u�J�n�̃��b�Z�[�W
        ''' </summary>
        Msg0011 = 4170011

        ''' <summary>
        ''' �A�[�J�C�u�I���̃��b�Z�[�W
        ''' </summary>
        Msg0012 = 4170012

        ''' <summary>
        ''' �����J�n�̃��b�Z�[�W
        ''' </summary>
        Msg0013 = 4170013

        ''' <summary>
        ''' �����I���̃��b�Z�[�W
        ''' </summary>
        Msg0014 = 4170014

        ''' <summary>
        ''' �A�[�J�C�u���畜�����J�n����ꍇ�̃��b�Z�[�W
        ''' </summary>
        Msg0015 = 4170015

        ''' <summary>
        ''' �o�^�ς݃��R�[�h�̂��߁A�ꎞ�e�[�u���ւ̓o�^���X�L�b�v�����ꍇ�̃��b�Z�[�W
        ''' </summary>
        Msg0016 = 4170016

        ''' <summary>
        ''' �e�l���f�[�^�̃}�[�W�J�n���b�Z�[�W
        ''' </summary>
        Msg0017 = 4170017

    End Enum

#End Region

#Region " VANC "

    ''' <summary>
    ''' R@bitFlow NotesConveter �̏�񃁃b�Z�[�W���i�[�������\�[�X�̃��\�[�X����񋟂��܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VANC]

        ''' <summary>
        '''�t�H�[����`�t�@�C���͐���ɕۑ�����܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        WriteXMLComplete = 4180001

        ''' <summary>
        '''�f�[�^�A�b�v���[�h��`�t�@�C���͐���ɕۑ�����܂����B{0}�ꎞ�f�[�^�쐬�����s���ĉ������B 
        ''' </summary>
        ''' <remarks></remarks>
        WriteDataXMLComplete = 4180002

        ''' <summary>
        '''�A�b�v���[�h���I�����܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        UploadComplete = 4180003

        ''' <summary>
        '''����}�X�^�ɂ͈ꌏ���f�[�^�����݂��܂���B 
        ''' </summary>
        ''' <remarks></remarks>
        SelectNoSeiyakuData = 4180004

        ''' <summary>
        '''����}�X�^�̍X�V�����s���܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        CreateSeiyakuDataErr = 4180005

        ''' <summary>
        '''����}�X�^�̍X�V���I�����܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        CreateSeiyakuDataComplete = 4180006

        ''' <summary>
        '''���������f����܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        AbortUpdate = 4180007

        ''' <summary>
        '''�ꎞ�f�[�^�Ɛݒ�t�@�C���̓��e���قȂ�܂��B{0}�ꎞ�f�[�^�쐬�����蒼���Ă��������B 
        ''' </summary>
        ''' <remarks></remarks>
        ChengedMappingFiles = 4180008

        ''' <summary>
        '''�ڍs��t�H�[�����Ăяo��GUI�����݂��܂���B 
        ''' </summary>
        ''' <remarks></remarks>
        NothingCallSubFrmGui = 4180010

        ''' <summary>
        '''�ꎞ�f�[�^�쐬�͒��f����܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        AbortCreate = 4180011

        ''' <summary>
        '''�ꎞ�f�[�^�쐬�͊������܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        AlreadyCreateed = 4180012

        ''' <summary>
        '''�t�H�[���̃R�s�[���I�����܂����B{0}�V�t�H�[���h�c�́u{1}�v�ł��B
        ''' </summary>
        ''' <remarks></remarks>
        CopyEnd = 4180013

        ''' <summary>
        '''�f�[�^�̓o�^���������܂����B{0}�����F{1}���A���s�F{2}��
        ''' </summary>
        ''' <remarks></remarks>
        UpdatedUserMapping = 4180014

        ''' <summary>
        '''�ꎞ�f�[�^�͐���ɍ쐬����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        DataCreated = 4180015

        ''' <summary>
        '''�f�[�^�̃A�b�v���[�h���������܂����I
        ''' </summary>
        ''' <remarks></remarks>
        DataUploaded = 4180016

        '''' <summary>
        ''''�o�^����f�[�^�����݂��܂���B
        '''' </summary>
        '''' <remarks></remarks>
        'EmptyData = 4180017

        ''' <summary>
        '''{0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 4180018

        ''' <summary>
        '''�o�b�`��`�t�@�C���͐���ɕۑ�����܂����B
        ''' </summary>
        ''' <remarks></remarks>
        FileSaved = 4180019

        ''' <summary>
        '''{0}���ړo�^�����B{1}�����F{2}���A���s�F{3}��
        ''' </summary>
        ''' <remarks></remarks>
        MappingDataInsertedInfo = 4180020

        ''' <summary>
        '''�A�b�v���[�h�����f����܂����B 
        ''' </summary>
        ''' <remarks></remarks>
        UploadAborted = 4180021
    End Enum

#End Region
End Namespace
