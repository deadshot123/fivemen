// $Id: IPPorts.cs,v 1.1.1.1 2007/07/03 10:15:18 tamirgal Exp $

/// <summary>************************************************************************
/// Copyright (C) 2001, Patrick Charles and Jonas Lehmann                   *
/// Distributed under the Mozilla Public License                            *
/// http://www.mozilla.org/NPL/MPL-1.1.txt                                *
/// *************************************************************************
/// </summary>
using System;
namespace Tamir.IPLib.Packets
{
	
	
	/// <summary> Code constants for ip ports.
	/// 
	/// </summary>
	/// <author>  Patrick Charles and Jonas Lehmann
	/// </author>
	/// <version>  $Revision: 1.1.1.1 $
	/// </version>
	/// <lastModifiedBy>  $Author: tamirgal $ </lastModifiedBy>
	/// <lastModifiedAt>  $Date: 2007/07/03 10:15:18 $ </lastModifiedAt>
	public struct IPPorts_Fields{
		public readonly static int NONE = - 1; // dummy value for protocols that don't use ports
		public readonly static int RESERVED_0 = 0;
		public readonly static int TCPMUX = 1;
		public readonly static int COMPRESSNET2 = 2;
		public readonly static int COMPRESSNET = 3;
		public readonly static int RJE = 5;
		public readonly static int ECHO = 7;
		public readonly static int DISCARD = 9;
		public readonly static int SYSTAT = 11;
		public readonly static int DAYTIME = 13;
		public readonly static int QOTD = 17;
		public readonly static int MSP = 18;
		public readonly static int CHARGEN = 19;
		public readonly static int FTP_DATA = 20;
		public readonly static int FTP = 21;
		public readonly static int SSH = 22;
		public readonly static int TELNET = 23;
		public readonly static int PRIV_MAIL = 24;
		public readonly static int SMTP = 25;
		public readonly static int NSW_FE = 27;
		public readonly static int MSG_ICP = 29;
		public readonly static int MSG_AUTH = 31;
		public readonly static int DSP = 33;
		public readonly static int PRIV_PRINT = 35;
		public readonly static int TIME = 37;
		public readonly static int RAP = 38;
		public readonly static int RLP = 39;
		public readonly static int GRAPHICS = 41;
		public readonly static int NAME = 42;
		public readonly static int NAMESERVER = 42;
		public readonly static int NICNAME = 43;
		public readonly static int MPM_FLAGS = 44;
		public readonly static int MPM = 45;
		public readonly static int MPM_SND = 46;
		public readonly static int NI_FTP = 47;
		public readonly static int AUDITD = 48;
		public readonly static int TACACS = 49;
		public readonly static int RE_MAIL_CK = 50;
		public readonly static int LA_MAINT = 51;
		public readonly static int XNS_TIME = 52;
		public readonly static int DOMAIN = 53;
		public readonly static int XNS_CH = 54;
		public readonly static int ISI_GL = 55;
		public readonly static int XNS_AUTH = 56;
		public readonly static int PRIV_TERMINAL = 57;
		public readonly static int XNS_MAIL = 58;
		public readonly static int PRIV_FILE = 59;
		public readonly static int NI_MAIL = 61;
		public readonly static int ACAS = 62;
		public readonly static int WHOIS = 63;
		public readonly static int COVIA = 64;
		public readonly static int TACACS_DS = 65;
		public readonly static int SQLSNET = 66;
		public readonly static int BOOTPS = 67;
		public readonly static int BOOTPC = 68;
		public readonly static int TFTP = 69;
		public readonly static int GOPHER = 70;
		public readonly static int NETRJS_1 = 71;
		public readonly static int NETRJS_2 = 72;
		public readonly static int NETRJS_3 = 73;
		public readonly static int NETRJS_4 = 74;
		public readonly static int PRIV_DIALOUT = 75;
		public readonly static int DEOS = 76;
		public readonly static int PRIV_RJE = 77;
		public readonly static int VETTCP = 78;
		public readonly static int FINGER = 79;
		public readonly static int HTTP = 80;
		public readonly static int WWW = 80;
		public readonly static int HOSTS2_NS = 81;
		public readonly static int XFER = 82;
		public readonly static int MIT_ML_DEV = 83;
		public readonly static int CTF = 84;
		public readonly static int MIT_ML_DEV2 = 85;
		public readonly static int MFCOBOL = 86;
		public readonly static int PRIV_TERMLINK = 87;
		public readonly static int KERBEROS = 88;
		public readonly static int SU_MIT_TG = 89;
		public readonly static int DNSIX = 90;
		public readonly static int MIT_DOV = 91;
		public readonly static int NPP = 92;
		public readonly static int DCP = 93;
		public readonly static int OBJCALL = 94;
		public readonly static int SUPDUP = 95;
		public readonly static int DIXIE = 96;
		public readonly static int SWIFT_RVF = 97;
		public readonly static int TACNEWS = 98;
		public readonly static int METAGRAM = 99;
		public readonly static int NEWACCT = 100;
		public readonly static int HOSTNAME = 101;
		public readonly static int ISO_TSAP = 102;
		public readonly static int GPPITNP = 103;
		public readonly static int ACR_NEMA = 104;
		public readonly static int CSO = 105;
		public readonly static int CSNET_NS = 105;
		public readonly static int TSMUX_3COM = 106;
		public readonly static int RTELNET = 107;
		public readonly static int SNAGAS = 108;
		public readonly static int POP2 = 109;
		public readonly static int POP3 = 110;
		public readonly static int SUNRPC = 111;
		public readonly static int MCIDAS = 112;
		public readonly static int IDENT = 113;
		public readonly static int AUTH = 113;
		public readonly static int AUDIONEWS = 114;
		public readonly static int SFTP = 115;
		public readonly static int ANSANOTIFY = 116;
		public readonly static int UUCP_PATH = 117;
		public readonly static int SQLSERV = 118;
		public readonly static int NNTP = 119;
		public readonly static int CFDPTKT = 120;
		public readonly static int ERPC = 121;
		public readonly static int SMAKYNET = 122;
		public readonly static int NTP = 123;
		public readonly static int ANSATRADER = 124;
		public readonly static int LOCUS_MAP = 125;
		public readonly static int NXEDIT = 126;
		public readonly static int LOCUS_CON = 127;
		public readonly static int GSS_XLICEN = 128;
		public readonly static int PWDGEN = 129;
		public readonly static int CISCO_FNA = 130;
		public readonly static int CISCO_TNA = 131;
		public readonly static int CISCO_SYS = 132;
		public readonly static int STATSRV = 133;
		public readonly static int INGRES_NET = 134;
		public readonly static int EPMAP = 135;
		public readonly static int PROFILE = 136;
		public readonly static int NETBIOS_NS = 137;
		public readonly static int NETBIOS_DGM = 138;
		public readonly static int NETBIOS_SSN = 139;
		public readonly static int EMFIS_DATA = 140;
		public readonly static int EMFIS_CNTL = 141;
		public readonly static int BL_IDM = 142;
		public readonly static int IMAP = 143;
		public readonly static int UMA = 144;
		public readonly static int UAAC = 145;
		public readonly static int ISO_TP0 = 146;
		public readonly static int ISO_IP = 147;
		public readonly static int JARGON = 148;
		public readonly static int AED_512 = 149;
		public readonly static int SQL_NET = 150;
		public readonly static int HEMS = 151;
		public readonly static int BFTP = 152;
		public readonly static int SGMP = 153;
		public readonly static int NETSC_PROD = 154;
		public readonly static int NETSC_DEV = 155;
		public readonly static int SQLSRV = 156;
		public readonly static int KNET_CMP = 157;
		public readonly static int PCMAIL_SRV = 158;
		public readonly static int NSS_ROUTING = 159;
		public readonly static int SGMP_TRAPS = 160;
		public readonly static int SNMP = 161;
		public readonly static int SNMPTRAP = 162;
		public readonly static int CMIP_MAN = 163;
		public readonly static int CMIP_AGENT = 164;
		public readonly static int XNS_COURIER = 165;
		public readonly static int S_NET = 166;
		public readonly static int NAMP = 167;
		public readonly static int RSVD = 168;
		public readonly static int SEND = 169;
		public readonly static int PRINT_SRV = 170;
		public readonly static int MULTIPLEX = 171;
		public readonly static int CL1 = 172;
		public readonly static int XYPLEX_MUX = 173;
		public readonly static int MAILQ = 174;
		public readonly static int VMNET = 175;
		public readonly static int GENRAD_MUX = 176;
		public readonly static int XDMCP = 177;
		public readonly static int NEXTSTEP = 178;
		public readonly static int BGP = 179;
		public readonly static int RIS = 180;
		public readonly static int UNIFY = 181;
		public readonly static int AUDIT = 182;
		public readonly static int OCBINDER = 183;
		public readonly static int OCSERVER = 184;
		public readonly static int REMOTE_KIS = 185;
		public readonly static int KIS = 186;
		public readonly static int ACI = 187;
		public readonly static int MUMPS = 188;
		public readonly static int QFT = 189;
		public readonly static int GACP = 190;
		public readonly static int PROSPERO = 191;
		public readonly static int OSU_NMS = 192;
		public readonly static int SRMP = 193;
		public readonly static int IRC = 194;
		public readonly static int DN6_NLM_AUD = 195;
		public readonly static int DN6_SMM_RED = 196;
		public readonly static int DLS = 197;
		public readonly static int DLS_MON = 198;
		public readonly static int SMUX = 199;
		public readonly static int SRC = 200;
		public readonly static int AT_RTMP = 201;
		public readonly static int AT_NBP = 202;
		public readonly static int AT_3 = 203;
		public readonly static int AT_ECHO = 204;
		public readonly static int AT_5 = 205;
		public readonly static int AT_ZIS = 206;
		public readonly static int AT_7 = 207;
		public readonly static int AT_8 = 208;
		public readonly static int QMTP = 209;
		public readonly static int Z39_50 = 210;
		public readonly static int N914C = 211;
		public readonly static int ANET = 212;
		public readonly static int IPX = 213;
		public readonly static int VMPWSCS = 214;
		public readonly static int SOFTPC = 215;
		public readonly static int CAILIC = 216;
		public readonly static int DBASE = 217;
		public readonly static int MPP = 218;
		public readonly static int UARPS = 219;
		public readonly static int IMAP3 = 220;
		public readonly static int FLN_SPX = 221;
		public readonly static int RSH_SPX = 222;
		public readonly static int CDC = 223;
		public readonly static int MASQDIALER = 224;
		public readonly static int DIRECT = 242;
		public readonly static int SUR_MEAS = 243;
		public readonly static int INBUSINESS = 244;
		public readonly static int LINK = 245;
		public readonly static int DSP3270 = 246;
		public readonly static int SUBNTBCST_TFTP = 247;
		public readonly static int BHFHS = 248;
		public readonly static int RAP2 = 256;
		public readonly static int SET = 257;
		public readonly static int YAK_CHAT = 258;
		public readonly static int ESRO_GEN = 259;
		public readonly static int OPENPORT = 260;
		public readonly static int NSIIOPS = 261;
		public readonly static int ARCISDMS = 262;
		public readonly static int HDAP = 263;
		public readonly static int BGMP = 264;
		public readonly static int X_BONE_CTL = 265;
		public readonly static int SST = 266;
		public readonly static int TD_SERVICE = 267;
		public readonly static int TD_REPLICA = 268;
		public readonly static int HTTP_MGMT = 280;
		public readonly static int PERSONAL_LINK = 281;
		public readonly static int CABLEPORT_AX = 282;
		public readonly static int RESCAP = 283;
		public readonly static int CORERJD = 284;
		public readonly static int FXP_1 = 286;
		public readonly static int K_BLOCK = 287;
		public readonly static int NOVASTORBAKCUP = 308;
		public readonly static int ENTRUSTTIME = 309;
		public readonly static int BHMDS = 310;
		public readonly static int ASIP_WEBADMIN = 311;
		public readonly static int VSLMP = 312;
		public readonly static int MAGENTA_LOGIC = 313;
		public readonly static int OPALIS_ROBOT = 314;
		public readonly static int DPSI = 315;
		public readonly static int DECAUTH = 316;
		public readonly static int ZANNET = 317;
		public readonly static int PKIX_TIMESTAMP = 318;
		public readonly static int PTP_EVENT = 319;
		public readonly static int PTP_GENERAL = 320;
		public readonly static int PIP = 321;
		public readonly static int RTSPS = 322;
		public readonly static int TEXAR = 333;
		public readonly static int PDAP = 344;
		public readonly static int PAWSERV = 345;
		public readonly static int ZSERV = 346;
		public readonly static int FATSERV = 347;
		public readonly static int CSI_SGWP = 348;
		public readonly static int MFTP = 349;
		public readonly static int MATIP_TYPE_A = 350;
		public readonly static int MATIP_TYPE_B = 351;
		public readonly static int BHOETTY = 351;
		public readonly static int DTAG_STE_SB = 352;
		public readonly static int BHOEDAP4 = 352;
		public readonly static int NDSAUTH = 353;
		public readonly static int BH611 = 354;
		public readonly static int DATEX_ASN = 355;
		public readonly static int CLOANTO_NET = 356;
		public readonly static int BHEVENT = 357;
		public readonly static int SHRINKWRAP = 358;
		public readonly static int NSRMP = 359;
		public readonly static int SCOI2ODIALOG = 360;
		public readonly static int SEMANTIX = 361;
		public readonly static int SRSSEND = 362;
		public readonly static int RSVP_TUNNEL = 363;
		public readonly static int AURORA_CMGR = 364;
		public readonly static int DTK = 365;
		public readonly static int ODMR = 366;
		public readonly static int MORTGAGEWARE = 367;
		public readonly static int QBIKGDP = 368;
		public readonly static int RPC2PORTMAP = 369;
		public readonly static int CODAAUTH = 370;
		public readonly static int CLEARCASE = 371;
		public readonly static int ULISTPROC = 372;
		public readonly static int LEGENT_1 = 373;
		public readonly static int LEGENT_2 = 374;
		public readonly static int HASSLE = 375;
		public readonly static int NIP = 376;
		public readonly static int TNETOS = 377;
		public readonly static int DSETOS = 378;
		public readonly static int IS99C = 379;
		public readonly static int IS99S = 380;
		public readonly static int HP_COLLECTOR = 381;
		public readonly static int HP_MANAGED_NODE = 382;
		public readonly static int HP_ALARM_MGR = 383;
		public readonly static int ARNS = 384;
		public readonly static int IBM_APP = 385;
		public readonly static int ASA = 386;
		public readonly static int AURP = 387;
		public readonly static int UNIDATA_LDM = 388;
		public readonly static int UIS = 390;
		public readonly static int SYNOTICS_RELAY = 391;
		public readonly static int SYNOTICS_BROKER = 392;
		public readonly static int META5 = 393;
		public readonly static int EMBL_NDT = 394;
		public readonly static int NETCP = 395;
		public readonly static int NETWARE_IP = 396;
		public readonly static int MPTN = 397;
		public readonly static int KRYPTOLAN = 398;
		public readonly static int ISO_TSAP_C2 = 399;
		public readonly static int WORK_SOL = 400;
		public readonly static int UPS = 401;
		public readonly static int GENIE = 402;
		public readonly static int DECAP = 403;
		public readonly static int NCED = 404;
		public readonly static int NCLD = 405;
		public readonly static int IMSP = 406;
		public readonly static int TIMBUKTU = 407;
		public readonly static int PRM_SM = 408;
		public readonly static int PRM_NM = 409;
		public readonly static int DECLADEBUG = 410;
		public readonly static int RMT = 411;
		public readonly static int SYNOPTICS_TRAP = 412;
		public readonly static int SMSP = 413;
		public readonly static int INFOSEEK = 414;
		public readonly static int BNET = 415;
		public readonly static int SILVERPLATTER = 416;
		public readonly static int ONMUX = 417;
		public readonly static int HYPER_G = 418;
		public readonly static int ARIEL1 = 419;
		public readonly static int SMPTE = 420;
		public readonly static int ARIEL2 = 421;
		public readonly static int ARIEL3 = 422;
		public readonly static int OPC_JOB_START = 423;
		public readonly static int OPC_JOB_TRACK = 424;
		public readonly static int ICAD_EL = 425;
		public readonly static int SMARTSDP = 426;
		public readonly static int SVRLOC = 427;
		public readonly static int OCS_CMU = 428;
		public readonly static int OCS_AMU = 429;
		public readonly static int UTMPSD = 430;
		public readonly static int UTMPCD = 431;
		public readonly static int IASD = 432;
		public readonly static int NNSP = 433;
		public readonly static int MOBILEIP_AGENT = 434;
		public readonly static int MOBILIP_MN = 435;
		public readonly static int DNA_CML = 436;
		public readonly static int COMSCM = 437;
		public readonly static int DSFGW = 438;
		public readonly static int DASP = 439;
		public readonly static int SGCP = 440;
		public readonly static int DECVMS_SYSMGT = 441;
		public readonly static int CVC_HOSTD = 442;
		public readonly static int HTTPS = 443;
		public readonly static int SNPP = 444;
		public readonly static int MICROSOFT_DS = 445;
		public readonly static int DDM_RDB = 446;
		public readonly static int DDM_DFM = 447;
		public readonly static int DDM_SSL = 448;
		public readonly static int AS_SERVERMAP = 449;
		public readonly static int TSERVER = 450;
		public readonly static int SFS_SMP_NET = 451;
		public readonly static int SFS_CONFIG = 452;
		public readonly static int CREATIVESERVER = 453;
		public readonly static int CONTENTSERVER = 454;
		public readonly static int CREATIVEPARTNR = 455;
		public readonly static int MACON_TCP = 456;
		public readonly static int SCOHELP = 457;
		public readonly static int APPLEQTC = 458;
		public readonly static int AMPR_RCMD = 459;
		public readonly static int SKRONK = 460;
		public readonly static int DATASURFSRV = 461;
		public readonly static int DATASURFSRVSEC = 462;
		public readonly static int ALPES = 463;
		public readonly static int KPASSWD = 464;
		public readonly static int DIGITAL_VRC = 466;
		public readonly static int MYLEX_MAPD = 467;
		public readonly static int PHOTURIS = 468;
		public readonly static int RCP = 469;
		public readonly static int SCX_PROXY = 470;
		public readonly static int MONDEX = 471;
		public readonly static int LJK_LOGIN = 472;
		public readonly static int HYBRID_POP = 473;
		public readonly static int TN_TL_W1 = 474;
		public readonly static int TCPNETHASPSRV = 475;
		public readonly static int TN_TL_FD1 = 476;
		public readonly static int SS7NS = 477;
		public readonly static int SPSC = 478;
		public readonly static int IAFSERVER = 479;
		public readonly static int IAFDBASE = 480;
		public readonly static int PH = 481;
		public readonly static int BGS_NSI = 482;
		public readonly static int ULPNET = 483;
		public readonly static int INTEGRA_SME = 484;
		public readonly static int POWERBURST = 485;
		public readonly static int AVIAN = 486;
		public readonly static int SAFT = 487;
		public readonly static int GSS_HTTP = 488;
		public readonly static int NEST_PROTOCOL = 489;
		public readonly static int MICOM_PFS = 490;
		public readonly static int GO_LOGIN = 491;
		public readonly static int TICF_1 = 492;
		public readonly static int TICF_2 = 493;
		public readonly static int POV_RAY = 494;
		public readonly static int INTECOURIER = 495;
		public readonly static int PIM_RP_DISC = 496;
		public readonly static int DANTZ = 497;
		public readonly static int SIAM = 498;
		public readonly static int ISO_ILL = 499;
		public readonly static int ISAKMP = 500;
		public readonly static int STMF = 501;
		public readonly static int ASA_APPL_PROTO = 502;
		public readonly static int INTRINSA = 503;
		public readonly static int CITADEL = 504;
		public readonly static int MAILBOX_LM = 505;
		public readonly static int OHIMSRV = 506;
		public readonly static int CRS = 507;
		public readonly static int XVTTP = 508;
		public readonly static int SNARE = 509;
		public readonly static int FCP = 510;
		public readonly static int PASSGO = 511;
		public readonly static int EXEC = 512;
		public readonly static int LOGIN = 513;
		public readonly static int SHELL = 514;
		public readonly static int PRINTER = 515;
		public readonly static int VIDEOTEX = 516;
		public readonly static int TALK = 517;
		public readonly static int NTALK = 518;
		public readonly static int UTIME = 519;
		public readonly static int EFS = 520;
		public readonly static int RIPNG = 521;
		public readonly static int ULP = 522;
		public readonly static int IBM_DB2 = 523;
		public readonly static int NCP = 524;
		public readonly static int TIMED = 525;
		public readonly static int TEMPO = 526;
		public readonly static int STX = 527;
		public readonly static int CUSTIX = 528;
		public readonly static int IRC_SERV = 529;
		public readonly static int COURIER = 530;
		public readonly static int CONFERENCE = 531;
		public readonly static int NETNEWS = 532;
		public readonly static int NETWALL = 533;
		public readonly static int MM_ADMIN = 534;
		public readonly static int IIOP = 535;
		public readonly static int OPALIS_RDV = 536;
		public readonly static int NMSP = 537;
		public readonly static int GDOMAP = 538;
		public readonly static int APERTUS_LDP = 539;
		public readonly static int UUCP = 540;
		public readonly static int UUCP_RLOGIN = 541;
		public readonly static int COMMERCE = 542;
		public readonly static int KLOGIN = 543;
		public readonly static int KSHELL = 544;
		public readonly static int APPLEQTCSRVR = 545;
		public readonly static int DHCPV6_CLIENT = 546;
		public readonly static int DHCPV6_SERVER = 547;
		public readonly static int AFPOVERTCP = 548;
		public readonly static int IDFP = 549;
		public readonly static int NEW_RWHO = 550;
		public readonly static int CYBERCASH = 551;
		public readonly static int DEVICESHARE = 552;
		public readonly static int PIRP = 553;
		public readonly static int RTSP = 554;
		public readonly static int DSF = 555;
		public readonly static int REMOTEFS = 556;
		public readonly static int OPENVMS_SYSIPC = 557;
		public readonly static int SDNSKMP = 558;
		public readonly static int TEEDTAP = 559;
		public readonly static int RMONITOR = 560;
		public readonly static int MONITOR = 561;
		public readonly static int CHSHELL = 562;
		public readonly static int NNTPS = 563;
		public readonly static int N9PFS = 564;
		public readonly static int WHOAMI = 565;
		public readonly static int STREETTALK = 566;
		public readonly static int BANYAN_RPC = 567;
		public readonly static int MS_SHUTTLE = 568;
		public readonly static int MS_ROME = 569;
		public readonly static int METER = 570;
		public readonly static int METER2 = 571;
		public readonly static int SONAR = 572;
		public readonly static int BANYAN_VIP = 573;
		public readonly static int FTP_AGENT = 574;
		public readonly static int VEMMI = 575;
		public readonly static int IPCD = 576;
		public readonly static int VNAS = 577;
		public readonly static int IPDD = 578;
		public readonly static int DECBSRV = 579;
		public readonly static int SNTP_HEARTBEAT = 580;
		public readonly static int BDP = 581;
		public readonly static int SCC_SECURITY = 582;
		public readonly static int PHILIPS_VC = 583;
		public readonly static int KEYSERVER = 584;
		public readonly static int IMAP4_SSL = 585;
		public readonly static int PASSWORD_CHG = 586;
		public readonly static int SUBMISSION = 587;
		public readonly static int CAL = 588;
		public readonly static int EYELINK = 589;
		public readonly static int TNS_CML = 590;
		public readonly static int HTTP_ALT = 591;
		public readonly static int EUDORA_SET = 592;
		public readonly static int HTTP_RPC_EPMAP = 593;
		public readonly static int TPIP = 594;
		public readonly static int CAB_PROTOCOL = 595;
		public readonly static int SMSD = 596;
		public readonly static int PTCNAMESERVICE = 597;
		public readonly static int SCO_WEBSRVRMG3 = 598;
		public readonly static int ACP = 599;
		public readonly static int IPCSERVER = 600;
		public readonly static int URM = 606;
		public readonly static int NQS = 607;
		public readonly static int SIFT_UFT = 608;
		public readonly static int NPMP_TRAP = 609;
		public readonly static int NPMP_LOCAL = 610;
		public readonly static int NPMP_GUI = 611;
		public readonly static int HMMP_IND = 612;
		public readonly static int HMMP_OP = 613;
		public readonly static int SSHELL = 614;
		public readonly static int SCO_INETMGR = 615;
		public readonly static int SCO_SYSMGR = 616;
		public readonly static int SCO_DTMGR = 617;
		public readonly static int DEI_ICDA = 618;
		public readonly static int DIGITAL_EVM = 619;
		public readonly static int SCO_WEBSRVRMGR = 620;
		public readonly static int ESCP_IP = 621;
		public readonly static int COLLABORATOR = 622;
		public readonly static int AUX_BUS_SHUNT = 623;
		public readonly static int CRYPTOADMIN = 624;
		public readonly static int DEC_DLM = 625;
		public readonly static int ASIA = 626;
		public readonly static int PASSGO_TIVOLI = 627;
		public readonly static int QMQP = 628;
		public readonly static int AMP3_3COM = 629;
		public readonly static int RDA = 630;
		public readonly static int IPP = 631;
		public readonly static int BMPP = 632;
		public readonly static int SERVSTAT = 633;
		public readonly static int GINAD = 634;
		public readonly static int RLZDBASE = 635;
		public readonly static int LDAPS = 636;
		public readonly static int LANSERVER = 637;
		public readonly static int MCNS_SEC = 638;
		public readonly static int MSDP = 639;
		public readonly static int ENTRUST_SPS = 640;
		public readonly static int REPCMD = 641;
		public readonly static int ESRO_EMSDP = 642;
		public readonly static int SANITY = 643;
		public readonly static int DWR = 644;
		public readonly static int PSSC = 645;
		public readonly static int LDP = 646;
		public readonly static int DHCP_FAILOVER = 647;
		public readonly static int RRP = 648;
		public readonly static int AMINET = 649;
		public readonly static int OBEX = 650;
		public readonly static int IEEE_MMS = 651;
		public readonly static int HELLO_PORT = 652;
		public readonly static int REPSCMD = 653;
		public readonly static int AODV = 654;
		public readonly static int TINC = 655;
		public readonly static int SPMP = 656;
		public readonly static int RMC = 657;
		public readonly static int TENFOLD = 658;
		public readonly static int URL_RENDEZVOUS = 659;
		public readonly static int MAC_SRVR_ADMIN = 660;
		public readonly static int HAP = 661;
		public readonly static int PFTP = 662;
		public readonly static int PURENOISE = 663;
		public readonly static int SECURE_AUX_BUS = 664;
		public readonly static int SUN_DR = 665;
		public readonly static int MDQS = 666;
		public readonly static int DOOM = 666;
		public readonly static int DISCLOSE = 667;
		public readonly static int MECOMM = 668;
		public readonly static int MEREGISTER = 669;
		public readonly static int VACDSM_SWS = 670;
		public readonly static int VACDSM_APP = 671;
		public readonly static int VPPS_QUA = 672;
		public readonly static int CIMPLEX = 673;
		public readonly static int ACAP = 674;
		public readonly static int DCTP = 675;
		public readonly static int VPPS_VIA = 676;
		public readonly static int VPP = 677;
		public readonly static int GGF_NCP = 678;
		public readonly static int MRM = 679;
		public readonly static int ENTRUST_AAAS = 680;
		public readonly static int ENTRUST_AAMS = 681;
		public readonly static int XFR = 682;
		public readonly static int CORBA_IIOP = 683;
		public readonly static int CORBA_IIOP_SSL = 684;
		public readonly static int MDC_PORTMAPPER = 685;
		public readonly static int HCP_WISMAR = 686;
		public readonly static int ASIPREGISTRY = 687;
		public readonly static int REALM_RUSD = 688;
		public readonly static int NMAP = 689;
		public readonly static int VATP = 690;
		public readonly static int MSEXCH_ROUTING = 691;
		public readonly static int HYPERWAVE_ISP = 692;
		public readonly static int CONNENDP = 693;
		public readonly static int HA_CLUSTER = 694;
		public readonly static int IEEE_MMS_SSL = 695;
		public readonly static int RUSHD = 696;
		public readonly static int UUIDGEN = 697;
		public readonly static int OLSR = 698;
		public readonly static int ACCESSNETWORK = 699;
		public readonly static int ELCSD = 704;
		public readonly static int AGENTX = 705;
		public readonly static int SILC = 706;
		public readonly static int BORLAND_DSJ = 707;
		public readonly static int ENTRUST_KMSH = 709;
		public readonly static int ENTRUST_ASH = 710;
		public readonly static int CISCO_TDP = 711;
		public readonly static int NETVIEWDM1 = 729;
		public readonly static int NETVIEWDM2 = 730;
		public readonly static int NETVIEWDM3 = 731;
		public readonly static int NETGW = 741;
		public readonly static int NETRCS = 742;
		public readonly static int FLEXLM = 744;
		public readonly static int FUJITSU_DEV = 747;
		public readonly static int RIS_CM = 748;
		public readonly static int KERBEROS_ADM = 749;
		public readonly static int RFILE = 750;
		public readonly static int PUMP = 751;
		public readonly static int QRH = 752;
		public readonly static int RRH = 753;
		public readonly static int TELL = 754;
		public readonly static int NLOGIN = 758;
		public readonly static int CON = 759;
		public readonly static int NS = 760;
		public readonly static int RXE = 761;
		public readonly static int QUOTAD = 762;
		public readonly static int CYCLESERV = 763;
		public readonly static int OMSERV = 764;
		public readonly static int WEBSTER = 765;
		public readonly static int PHONEBOOK = 767;
		public readonly static int VID = 769;
		public readonly static int CADLOCK = 770;
		public readonly static int RTIP = 771;
		public readonly static int CYCLESERV2 = 772;
		public readonly static int SUBMIT = 773;
		public readonly static int RPASSWD = 774;
		public readonly static int ENTOMB = 775;
		public readonly static int WPAGES = 776;
		public readonly static int MULTILING_HTTP = 777;
		public readonly static int WPGS = 780;
		public readonly static int CONCERT = 786;
		public readonly static int QSC = 787;
		public readonly static int MDBS_DAEMON = 800;
		public readonly static int DEVICE = 801;
		public readonly static int FCP_UDP = 810;
		public readonly static int ITM_MCELL_S = 828;
		public readonly static int PKIX_3_CA_RA = 829;
		public readonly static int DHCP_FAILOVER2 = 847;
		public readonly static int RSYNC = 873;
		public readonly static int ICLCNET_LOCATE = 886;
		public readonly static int ICLCNET_SVINFO = 887;
		public readonly static int ACCESSBUILDER = 888;
		public readonly static int CDDBP = 888;
		public readonly static int OMGINITIALREFS = 900;
		public readonly static int SMPNAMERES = 901;
		public readonly static int IDEAFARM_CHAT = 902;
		public readonly static int IDEAFARM_CATCH = 903;
		public readonly static int XACT_BACKUP = 911;
		public readonly static int FTPS_DATA = 989;
		public readonly static int FTPS = 990;
		public readonly static int NAS = 991;
		public readonly static int TELNETS = 992;
		public readonly static int IMAPS = 993;
		public readonly static int IRCS = 994;
		public readonly static int POP3S = 995;
		public readonly static int VSINET = 996;
		public readonly static int MAITRD = 997;
		public readonly static int BUSBOY = 998;
		public readonly static int GARCON = 999;
		public readonly static int PUPROUTER = 999;
		public readonly static int CADLOCK2 = 1000;
		public readonly static int SURF = 1010;
		public readonly static int RESERVED_1023 = 1023;
		public readonly static int RESERVED_1024 = 1024;
		public readonly static int SOCKS = 1080;
		public readonly static int HSRP = 1985;
		public readonly static int CVS = 2401;
		public readonly static int AISES = 2783;
		public readonly static int X11 = 6000; public readonly static int X11_BEGIN = 6000;
		public readonly static int X11_END = 6063;
		/// <summary> Number of well-known (aka privileged) ports.</summary>
		public readonly static int LIMIT_PRIVILEGED = 1024;
		/// <summary> IP port mask.</summary>
		public readonly static int MASK = 0xffff;
	}
	public interface IPPorts
	{
		//UPGRADE_NOTE: Members of interface 'IPPorts' were extracted into structure 'IPPorts_Fields'. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1045'"
		
	}
}