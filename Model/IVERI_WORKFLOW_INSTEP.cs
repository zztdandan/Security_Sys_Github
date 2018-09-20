using System;
namespace AppBox.Model
{
    interface IVERI_WORKFLOW_INSTEP
    {
        string INSTEP_CONCLUSION { get; set; }
        string INSTEP_ID { get; set; }
        string INSTEP_USER { get; set; }
        string REC_CREATE_TIME { get; set; }
        string VERIFY_LINK_ID { get; set; }
        string WORKFLOW_EN_FLOW { get; set; }
        string WORKFLOW_ID { get; set; }
    }
}
