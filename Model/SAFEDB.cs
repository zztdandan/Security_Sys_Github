namespace AppBox.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SAFEDB : DbContext
    {
        public SAFEDB()
            : base("name=SAFEDB")
        {
        }


        //多上下文类用于同一数据库方法：
        //Enable-Migrations -ContextTypeName WRDBContext -MigrationsDirectory Migrations\WRDBContext
        //Enable-Migrations -ContextTypeName TXCGLContext -MigrationsDirectory Migrations\TXCGL
        // Add-Migration  -ConfigurationTypeName AppBox.Migrations.SAFEDB.Configuration
       
        //update-database  -ConfigurationTypeName AppBox.Migrations.SAFEDB.Configuration


        public virtual DbSet<RISK_INFOR_ARCHIVES> RISK_INFOR_ARCHIVES { get; set; }
        public virtual DbSet<SAFE_DATA_RANGE1> SAFE_DATA_RANGE1 { get; set; }
        public virtual DbSet<SAFE_EFFECT_T> SAFE_EFFECT_T { get; set; }
        public virtual DbSet<SAFE_HIDDEN_COMPARISONS> SAFE_HIDDEN_COMPARISONS { get; set; }
        public virtual DbSet<SAFE_HIDDEN_DELAY> SAFE_HIDDEN_DELAY { get; set; }
        public virtual DbSet<SAFE_HIDDEN_FLOW> SAFE_HIDDEN_FLOW { get; set; }
        public virtual DbSet<SAFE_HIDDEN_LOG> SAFE_HIDDEN_LOG { get; set; }
        public virtual DbSet<SAFE_HIDDEN_LOGIN> SAFE_HIDDEN_LOGIN { get; set; }
        public virtual DbSet<SAFE_HIDDEN_ROLE> SAFE_HIDDEN_ROLE { get; set; }
        public virtual DbSet<SAFE_HIDDEN_T> SAFE_HIDDEN_T { get; set; }
        public virtual DbSet<SAFE_HIDDEN_USER> SAFE_HIDDEN_USER { get; set; }
        public virtual DbSet<SAFE_MANAGE_T> SAFE_MANAGE_T { get; set; }
        public virtual DbSet<STD_SAFE_HIDDEN_INFOR> STD_SAFE_HIDDEN_INFOR { get; set; }
        public virtual DbSet<STD_SAFE_HIDDEN_SORT> STD_SAFE_HIDDEN_SORT { get; set; }
        public virtual DbSet<TB_ARGUMENT> TB_ARGUMENT { get; set; }
        public virtual DbSet<TB_BUSINESS> TB_BUSINESS { get; set; }
        public virtual DbSet<TB_COMPANY_INDEX_ASSIGNMENT> TB_COMPANY_INDEX_ASSIGNMENT { get; set; }
        public virtual DbSet<TB_COMPANY_INDEX_DATA> TB_COMPANY_INDEX_DATA { get; set; }
        public virtual DbSet<TB_FORMULA_ELEMENT> TB_FORMULA_ELEMENT { get; set; }
        public virtual DbSet<TB_PATTERN> TB_PATTERN { get; set; }
        public virtual DbSet<TB_PROBLEM> TB_PROBLEM { get; set; }
        public virtual DbSet<TB_REPORT> TB_REPORT { get; set; }
        public virtual DbSet<TB_REPORT_DATA> TB_REPORT_DATA { get; set; }
        public virtual DbSet<TB_REPORT_DATA_BASE> TB_REPORT_DATA_BASE { get; set; }
        public virtual DbSet<TB_REPORT_INDEX> TB_REPORT_INDEX { get; set; }
        public virtual DbSet<TB_TOTAL_MODEL_VAL> TB_TOTAL_MODEL_VAL { get; set; }
        public virtual DbSet<TB_TREE_T> TB_TREE_T { get; set; }
        public virtual DbSet<TB_TREE_T1> TB_TREE_T1 { get; set; }
        public virtual DbSet<TEST2> TEST2 { get; set; }
        public virtual DbSet<SAFE_DATA_RANGE> SAFE_DATA_RANGE { get; set; }
        public virtual DbSet<SAFE_FUN_BUSINESS> SAFE_FUN_BUSINESS { get; set; }
        public virtual DbSet<SAFE_FUN_SORT> SAFE_FUN_SORT { get; set; }
        public virtual DbSet<SAFE_HIDDEN_BACK> SAFE_HIDDEN_BACK { get; set; }
        public virtual DbSet<TB_BUSINESS1> TB_BUSINESS1 { get; set; }
        public virtual DbSet<TB_MENU_POWER> TB_MENU_POWER { get; set; }
        public virtual DbSet<TB_SYS_CODE> TB_SYS_CODE { get; set; }
        public virtual DbSet<TB_TREE_T_POWER> TB_TREE_T_POWER { get; set; }

        public virtual DbSet<VERI_WORKFLOW_LINK> VERI_WORKFLOW_LINK { get; set; }
        public virtual DbSet<VERI_WORKFLOW_NODE> VERI_WORKFLOW_NODE { get; set; }
        public virtual DbSet<VERI_WORKFLOW> VERI_WORKFLOW { get; set; }

        public virtual DbSet<TH_TRISK01> TR_TRISK01 { get; set; }


        public virtual DbSet<TH_THAZA01> TH_THAZA01 { get; set; }
        public virtual DbSet<TH_THAZA02> TH_THAZA02 { get; set; }
        public virtual DbSet<EP_TEPEP01> EP_TEPEP01 { get; set; }
        public virtual DbSet<EP_TEPEP02> EP_TEPEP02 { get; set; }
        public virtual DbSet<ORG_JOBUNITRELATION_T> ORG_JOBUNITRELATION_T { get; set; }

        public virtual DbSet<VERI_WORKFLOW_INSTEP> VERI_WORKFLOW_INSTEP { get; set; }
        public virtual DbSet<TH_HAZALOCA> TH_HAZALOCA { get; set; }
        public virtual DbSet<SAFE_ROLEUSERS_T> SAFE_ROLEUSERS_T { get; set; }
        public virtual DbSet<VERI_ROLEAUTH_NODE> VERI_ROLEAUTH_NODE { get; set; }
        public virtual DbSet<HD_APP_DETAILFLOW> HD_APP_DETAILFLOW { get; set; }
        public virtual DbSet<VERI_ROLEAUTH_WORKFLOW> VERI_ROLEAUTH_WORKFLOW { get; set; }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SAFE");

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
              .Property(e => e.C_JOBCODE)
              .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_JOBNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_JOBLEVEL)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_LEVELNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_ROOTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_ROOTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_CORPCODE)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_CORPNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_CORPSUBCODE)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_CORPSUBNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_SECCODE)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_SECNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_KSCODE)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_KSNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_UNITCODE)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_UNITNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ORG_JOBUNITRELATION_T>()
                .Property(e => e.C_UNITFULLNAME)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CREATOR)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.UUID)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CORP_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.RISK_CONTENT)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.RISK_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.RISK_RANK)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.RISK_SOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.RISK_POSITION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.INVESTIGATION_PERSON)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHANGE_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHANGE_SITUATION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHANGE_DUTY_UNIT)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHANGE_DUTY_PERSON)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHANGE_BEFORE_SITUATION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHANGE_LATER_SITUATION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHECK_UNIT)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHECK_SITUATION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.REMARKS)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHANGE_FUND)
                .HasPrecision(8, 2);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.INTO_MANAGE_PLAN_SITUATION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHANGE_GOAL_SITUATION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.MEASURES_SITUATION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHANGE_FUND_SITUATION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHANGE_DUTY_SITUATION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHANGE_TIME_SITUATION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.EMERGENCY_PLAN_SITUATION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.SUP_DUTY_UNIT)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.SUP_DUTY_PERSON)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.LISTING_SUP_RANK)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.LISTING_SUP_NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.LISTING_SUP_UNIT)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.DELIST_UNIT)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CORP_UUID)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.LISTING_SITUATION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.RISK_SOLUTIONS_SUMMARY)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.MANAGE_GOAL_TASK)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.TAKEN_MEASURES)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.FUNDS_GOODS_PRACTICAL)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.GOVERN_ORGAN_STAFF)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.MANAGE_TIME_CLAIM)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.SAFETY_EMERGENCY_PLAN)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.RISK_STATUS_REASON)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.RISK_DAMAGE_DIFFICULTY)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.CHECK_DESCRIBE)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.FIND_RISK_UNIT_UUID)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.RISK_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.IS_UP_REPORT)
                .IsUnicode(false);

            modelBuilder.Entity<RISK_INFOR_ARCHIVES>()
                .Property(e => e.FIND_RISK_UNIT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_DATA_RANGE1>()
                .Property(e => e.ROLE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_DATA_RANGE1>()
                .Property(e => e.NODE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_DATA_RANGE1>()
                .Property(e => e.DATA_RANGE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_DATA_RANGE1>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_DATA_RANGE1>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_EFFECT_T>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_EFFECT_T>()
                .Property(e => e.ASSESS_TYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_EFFECT_T>()
                .Property(e => e.ACCOUNTABILITY_UNIT)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_EFFECT_T>()
                .Property(e => e.ACCOUNTABILITY_DEPARTMENT)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_EFFECT_T>()
                .Property(e => e.ASSESS_PERSON1)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_EFFECT_T>()
                .Property(e => e.ASSESS_PERSON2)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_EFFECT_T>()
                .Property(e => e.REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_COMPARISONS>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_COMPARISONS>()
                .Property(e => e.ROLE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_COMPARISONS>()
                .Property(e => e.FUNCTION_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_COMPARISONS>()
                .Property(e => e.SET_PEOPLE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_DELAY>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_DELAY>()
                .Property(e => e.ENTERING_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_DELAY>()
                .Property(e => e.EXTENSION_CAUSE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_DELAY>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.ENTERING_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.REPORT_ASSIGM)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.REPORT_ASSIGM_PERSON)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.ACCOUNTABILITY_UNIT)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.ACCOUNTABILITY_DEPARTMENT)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.ACCOUNTABILITY_GROUP)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.RECEIVE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.RECEIVE_IDENTIFYING)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.ZGYQ)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.HANDLE_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.FATHER_FLOWID)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.BACK_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.OLD_FUN_LEV)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.ZGYQBZ)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.MANAGE_LEVEL)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.ZGR)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.ZGLX)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.ZGXGPG)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.ZGXGPGSM)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.ROLE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_FLOW>()
                .Property(e => e.ZN_ORDER)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_LOG>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_LOG>()
                .Property(e => e.SET_PEOPLE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_LOG>()
                .Property(e => e.RZ_CZLX)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_LOGIN>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_LOGIN>()
                .Property(e => e.C_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_LOGIN>()
                .Property(e => e.C_PASS)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_LOGIN>()
                .Property(e => e.SET_PEOPLE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_ROLE>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_ROLE>()
                .Property(e => e.ROLE_LEV)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_ROLE>()
                .Property(e => e.ROLE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_ROLE>()
                .Property(e => e.BZ)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_ROLE>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_ROLE>()
                .Property(e => e.ORD)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.FUN_LEV)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.C_SECONDUNITID)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.YHLB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.YHLY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.YHBGZY)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.JCQKMS)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.CHECK_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.YHJB)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.YHBW)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.PHOT01)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.PHOT02)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.PHOT03)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.PHOT04)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.PHOT05)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.ZGQK)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.ZGXGPG)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.ZGLX)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.ZGYQ)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.ZGZJ)
                .HasPrecision(22, 2);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.YFKZCS)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.ZRDW)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.ZRBM)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.ZRBZ)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.ZRR)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.HISTORY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.CXXDZG)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.ZGXGPGSM)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.HANDLE_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.AFTER_PHOTO1)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.AFTER_PHOTO2)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.AFTER_PHOTO3)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.AFTER_PHOTO4)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.AFTER_PHOTO5)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.RENEW_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.YHBM)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.FLOW_DIAGRAM)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_T>()
                .Property(e => e.EXAM_SITUATION)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_USER>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_USER>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_USER>()
                .Property(e => e.CHINESENAME)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_USER>()
                .Property(e => e.ENABLED)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_USER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_USER>()
                .Property(e => e.OFFICEPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_USER>()
                .Property(e => e.HOMEPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_USER>()
                .Property(e => e.TELPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_USER>()
                .Property(e => e.REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_USER>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_USER>()
                .Property(e => e.ROLE_IDENTITY)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_USER>()
                .Property(e => e.SAFE_ROLE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.LEIBIE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.MANAGE_UNIT)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.MANAGE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.EMPLOY_UNIT)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.EU_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.EMPLOY_DEPARTMENT)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.ED_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.EMPLOY_GROUP)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.EG_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.EQUIPMENT)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.FACTORY)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.SIZE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.PLACE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.USER_MODE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.PERIOD)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.SERIAL)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.TEST)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.OUTCOME)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_MANAGE_T>()
                .Property(e => e.INSERT_TIME)
                .IsUnicode(false);

            modelBuilder.Entity<STD_SAFE_HIDDEN_INFOR>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STD_SAFE_HIDDEN_INFOR>()
                .Property(e => e.CLASSES_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<STD_SAFE_HIDDEN_INFOR>()
                .Property(e => e.INFORMATION_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<STD_SAFE_HIDDEN_INFOR>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<STD_SAFE_HIDDEN_INFOR>()
                .Property(e => e.CZLX)
                .IsUnicode(false);

            modelBuilder.Entity<STD_SAFE_HIDDEN_INFOR>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<STD_SAFE_HIDDEN_INFOR>()
                .Property(e => e.CLASSES_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<STD_SAFE_HIDDEN_INFOR>()
                .Property(e => e.DESCRIBE)
                .IsUnicode(false);

            modelBuilder.Entity<STD_SAFE_HIDDEN_SORT>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STD_SAFE_HIDDEN_SORT>()
                .Property(e => e.NODE_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<STD_SAFE_HIDDEN_SORT>()
                .Property(e => e.NODE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<STD_SAFE_HIDDEN_SORT>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<STD_SAFE_HIDDEN_SORT>()
                .Property(e => e.TREELEVEL)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.ARGUMENT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.ARGUMENT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.SYMBOL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.FORMULA)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.ISACTIVE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.ARGUMENT_REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.ARGUMENT_VALUE)
                .HasPrecision(22, 2);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.CATELOG)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.ARGUMENT_LAYER)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.UPDATE_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.CLASS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.AFFILIATION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.AFFILIATED_DEPARTMENT)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ARGUMENT>()
                .Property(e => e.AFFILIATED_GROUP)
                .IsUnicode(false);

            modelBuilder.Entity<TB_BUSINESS>()
                .Property(e => e.BUSINESS_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_BUSINESS>()
                .Property(e => e.BUSINESS_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_BUSINESS>()
                .Property(e => e.NODE_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_BUSINESS>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_BUSINESS>()
                .Property(e => e.NODE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_BUSINESS>()
                .Property(e => e.OPERATION_TYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_COMPANY_INDEX_ASSIGNMENT>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_COMPANY_INDEX_ASSIGNMENT>()
                .Property(e => e.REPORT_INDEX_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_COMPANY_INDEX_ASSIGNMENT>()
                .Property(e => e.C_SECCODE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_COMPANY_INDEX_ASSIGNMENT>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_COMPANY_INDEX_DATA>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_COMPANY_INDEX_DATA>()
                .Property(e => e.REPORT_INDEX_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_COMPANY_INDEX_DATA>()
                .Property(e => e.INDEX_VALUE)
                .HasPrecision(22, 2);

            modelBuilder.Entity<TB_COMPANY_INDEX_DATA>()
                .Property(e => e.YEAR1)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_COMPANY_INDEX_DATA>()
                .Property(e => e.MONTH1)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_COMPANY_INDEX_DATA>()
                .Property(e => e.WEEK1)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_COMPANY_INDEX_DATA>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_COMPANY_INDEX_DATA>()
                .Property(e => e.C_SECCODE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_FORMULA_ELEMENT>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_FORMULA_ELEMENT>()
                .Property(e => e.PATTERN_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_FORMULA_ELEMENT>()
                .Property(e => e.ARGUMENT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_FORMULA_ELEMENT>()
                .Property(e => e.CATELOG)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_FORMULA_ELEMENT>()
                .Property(e => e.VALUE)
                .HasPrecision(22, 2);

            modelBuilder.Entity<TB_FORMULA_ELEMENT>()
                .Property(e => e.PARENT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_FORMULA_ELEMENT>()
                .Property(e => e.REPORT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_FORMULA_ELEMENT>()
                .Property(e => e.ACTIVE_FLAG)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_FORMULA_ELEMENT>()
                .Property(e => e.SEC_FLAG)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.PATTERN_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.SYMBOL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.ISACTIVE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.DANGER_THRESHOLD)
                .HasPrecision(22, 2);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.WARNING_THRESHOLD)
                .HasPrecision(22, 2);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.ATTENTION_THRESHOLD)
                .HasPrecision(22, 2);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.MAX_THRESHOLD)
                .HasPrecision(22, 2);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.FORMULA)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.UPDATE_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.REPORT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.PLUS_MINUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.AFFILIATION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.AFFILIATED_DEPARTMENT)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.AFFILIATED_GROUP)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PATTERN>()
                .Property(e => e.WEIGHT)
                .HasPrecision(22, 2);

            modelBuilder.Entity<TB_PROBLEM>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_PROBLEM>()
                .Property(e => e.REPORT_BASE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_PROBLEM>()
                .Property(e => e.PROBLEM_CONTENT)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PROBLEM>()
                .Property(e => e.SOLUTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PROBLEM>()
                .Property(e => e.APPENDIX1)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PROBLEM>()
                .Property(e => e.APPENDIX2)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PROBLEM>()
                .Property(e => e.APPENDIX3)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PROBLEM>()
                .Property(e => e.REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.PERIOD_VALUE)
                .HasPrecision(10, 2);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.PERIOD_UNIT)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.SEC_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.KS_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.REPORT_LAYER)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.REPORT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.UPDATE_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.ISACTIVE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.CLASS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.AFFILIATION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.AFFILIATED_DEPARTMENT)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT>()
                .Property(e => e.AFFILIATED_GROUP)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_DATA>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT_DATA>()
                .Property(e => e.REPORT_BASE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT_DATA>()
                .Property(e => e.VALUE)
                .HasPrecision(22, 2);

            modelBuilder.Entity<TB_REPORT_DATA>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_DATA>()
                .Property(e => e.UPDATE_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_DATA>()
                .Property(e => e.REPORT_INDEX_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT_DATA>()
                .Property(e => e.CONFIRM_FLAG)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.CONCLUSION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.REPORT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.YEAR1)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.MONTH1)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.WEEK1)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.UPDATE_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.APPENDIX1)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.APPENDIX2)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.APPENDIX3)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.CONFIRM_FLAG)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.AFFILIATION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.AFFILIATED_DEPARTMENT)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_DATA_BASE>()
                .Property(e => e.AFFILIATED_GROUP)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_INDEX>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT_INDEX>()
                .Property(e => e.REPORT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT_INDEX>()
                .Property(e => e.INDEX_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_REPORT_INDEX>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_INDEX>()
                .Property(e => e.UPDATE_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REPORT_INDEX>()
                .Property(e => e.ISACTIVE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TOTAL_MODEL_VAL>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TOTAL_MODEL_VAL>()
                .Property(e => e.PATTERN_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TOTAL_MODEL_VAL>()
                .Property(e => e.AFFILIATION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TOTAL_MODEL_VAL>()
                .Property(e => e.YEAR1)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TOTAL_MODEL_VAL>()
                .Property(e => e.MONTH1)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TOTAL_MODEL_VAL>()
                .Property(e => e.VALUE1)
                .HasPrecision(22, 2);

            modelBuilder.Entity<TB_TOTAL_MODEL_VAL>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TOTAL_MODEL_VAL>()
                .Property(e => e.WEIGHT)
                .HasPrecision(22, 2);

            modelBuilder.Entity<TB_TOTAL_MODEL_VAL>()
                .Property(e => e.PLUS_MINUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T>()
                .Property(e => e.NODE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T>()
                .Property(e => e.PARENT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T>()
                .Property(e => e.NODE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T>()
                .Property(e => e.TARGET)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T>()
                .Property(e => e.EXPANDED)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T>()
                .Property(e => e.NODE_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T>()
                .Property(e => e.TREELEVEL)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T>()
                .Property(e => e.REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T>()
                .Property(e => e.HELP_URL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T>()
                .Property(e => e.HELP_ZD_URL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T>()
                .Property(e => e.FLAG_MODEL)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.NODE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.PARENT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.NODE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.TARGET)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.EXPANDED)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.NODE_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.TREELEVEL)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.HELP_URL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.HELP_ZD_URL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.ORD)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T1>()
                .Property(e => e.FLAG_MODEL)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TEST2>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_DATA_RANGE>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_DATA_RANGE>()
                .Property(e => e.FUN_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_DATA_RANGE>()
                .Property(e => e.BUSINESS_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_DATA_RANGE>()
                .Property(e => e.NODE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_DATA_RANGE>()
                .Property(e => e.DATA_RANGE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_DATA_RANGE>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_FUN_BUSINESS>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_FUN_BUSINESS>()
                .Property(e => e.FUN_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_FUN_BUSINESS>()
                .Property(e => e.BUSINESS_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_FUN_BUSINESS>()
                .Property(e => e.MANIPULATION_NODE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_FUN_BUSINESS>()
                .Property(e => e.MANIPULATION_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_FUN_BUSINESS>()
                .Property(e => e.OPERATION_TYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_FUN_BUSINESS>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_FUN_SORT>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_FUN_SORT>()
                .Property(e => e.FUN_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_FUN_SORT>()
                .Property(e => e.SORT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_FUN_SORT>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_BACK>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_BACK>()
                .Property(e => e.FLOW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_BACK>()
                .Property(e => e.BACK_REASON)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_BACK>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_BACK>()
                .Property(e => e.ZGYQ)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_HIDDEN_BACK>()
                .Property(e => e.ZGLX)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_HIDDEN_BACK>()
                .Property(e => e.ZGYQBZ)
                .IsUnicode(false);

            modelBuilder.Entity<TB_BUSINESS1>()
                .Property(e => e.ROLE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_BUSINESS1>()
                .Property(e => e.NODE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_BUSINESS1>()
                .Property(e => e.MANIPULATION_NODE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_BUSINESS1>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU_POWER>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_MENU_POWER>()
                .Property(e => e.MENU_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_MENU_POWER>()
                .Property(e => e.POWER_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_MENU_POWER>()
                .Property(e => e.POWER_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU_POWER>()
                .Property(e => e.REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU_POWER>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_SYS_CODE>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_SYS_CODE>()
                .Property(e => e.TYPE_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_SYS_CODE>()
                .Property(e => e.TYPE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_SYS_CODE>()
                .Property(e => e.C_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_SYS_CODE>()
                .Property(e => e.C_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_SYS_CODE>()
                .Property(e => e.ORDERID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_SYS_CODE>()
                .Property(e => e.REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<TB_SYS_CODE>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T_POWER>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T_POWER>()
                .Property(e => e.NODE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T_POWER>()
                .Property(e => e.POWER_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TB_TREE_T_POWER>()
                .Property(e => e.POWER_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T_POWER>()
                .Property(e => e.REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TREE_T_POWER>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_ROLEUSERS_T>()
             .Property(e => e.ROLE_ID)
             .HasPrecision(38, 0);

            modelBuilder.Entity<SAFE_ROLEUSERS_T>()
                .Property(e => e.C_SECCODE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_ROLEUSERS_T>()
                .Property(e => e.C_KSCODE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_ROLEUSERS_T>()
                .Property(e => e.C_UNITCODE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_ROLEUSERS_T>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_ROLEUSERS_T>()
                .Property(e => e.SET_PEOPLE)
                .IsUnicode(false);

            modelBuilder.Entity<SAFE_ROLEUSERS_T>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);
        }
    }
}
