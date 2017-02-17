﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMClient.Utils
{
    public static class Const
    {
        /*public static Dictionary<string, string> ReqFieldsIgnoreRbt = new Dictionary<string, string>()
        {
            {"RQ_REQ_ID","id"},
            { "RQ_FATHER_ID","parent-id"},
            { "RQ_ORDER_ID","order-id"},
            { "RQ_ISTEMPLATE","istemplate"},
            { "RQ_REQ_COMMENT","description"},
            { "RQ_REQ_REVIEWED","req-reviewed"},
            { "RQ_REQ_PATH","hierarchical-path"},
            { "RQ_REQ_STATUS","status"},
            { "RQ_REQ_PRIORITY","req-priority"},
            { "RQ_REQ_TYPE","req-type"},
            { "RQ_REQ_PRODUCT","req-product"},
            { "RQ_REQ_NAME","name"},
            { "RQ_REQ_AUTHOR","owner"},
            { "RQ_REQ_VER_STAMP","ver-stamp"},
            { "RQ_ATTACHMENT","attachment"},
            { "RQ_REQ_DATE","creation-time"},
            { "RQ_REQ_TIME","req-time"},
            { "RQ_NO_OF_SONS","no-of-sons"},
            { "RQ_VTS","last-modified"},
            { "RQ_REQUEST_ID","request-id"},
            { "RQ_REQUEST_SERVER","request-server"},
            { "RQ_REQUEST_TYPE","request-type"},
            { "RQ_REQUEST_STATUS","request-status"},
            { "RQ_REQUEST_UPDATES","request-updates"},
            { "RQ_REQUEST_ASSIGN_TO","request-assign-to"},
            { "RQ_REQUEST_NOTE","request-note"},
            { "RQ_TYPE_ID","type-id"},
            { "RQ_TARGET_RCYC_VARCHAR","target-rcyc"},
            { "RQ_TARGET_REL_VARCHAR","target-rel"},
            { "RQ_DEV_COMMENTS","comments"},
            { "RQ_HAS_RICH_CONTENT","has-rich-content"},
            { "RQ_VC_VERSION_NUMBER","vc-version-number"},
            { "RQ_VC_STATUS","vc-status"},
            { "RQ_VC_CHECKIN_USER_NAME","vc-checkin-user-name"},
            { "RQ_VC_CHECKIN_DATE","vc-checkin-date"},
            { "RQ_VC_CHECKIN_TIME","vc-checkin-time"},
            { "RQ_VC_CHECKIN_COMMENTS","vc-checkin-comments"},
            { "RQ_VC_CHECKOUT_USER_NAME","check-out-user-name"},
            { "RQ_VC_CHECKOUT_DATE","vc-checkout-date"},
            { "RQ_VC_CHECKOUT_TIME","vc-checkout-time"},
            { "RQ_VC_CHECKOUT_COMMENTS","vc-checkout-comments"},
            { "RQ_REQ_RICH_CONTENT","req-rich-content"}
        };*/

        /*public static Dictionary<string, string> ReqFields = new Dictionary<string, string>()
        {
            {"RQ_REQ_ID","id"},
            { "RQ_FATHER_ID","parent-id"},
            { "RQ_ORDER_ID","order-id"},
            { "RQ_ISTEMPLATE","istemplate"},
            { "RQ_REQ_COMMENT","description"},
            { "RQ_REQ_REVIEWED","req-reviewed"},
            { "RQ_REQ_PATH","hierarchical-path"},
            { "RQ_REQ_STATUS","status"},
            { "RQ_REQ_PRIORITY","req-priority"},
            { "RQ_REQ_TYPE","req-type"},
            { "RQ_REQ_PRODUCT","req-product"},
            { "RQ_REQ_NAME","name"},
            { "RQ_REQ_AUTHOR","owner"},
            { "RQ_RBT_IGNORE_IN_ANALYSIS","rbt-ignore-in-analysis"},
            { "RQ_RBT_BSNS_IMPACT","rbt-bsns-impact"},
            { "RQ_RBT_CUSTOM_BSNS_IMPACT","rbt-custom-bsns-impact"},
            { "RQ_RBT_USE_CUSTOM_BSNS_IMPACT","rbt-use-custom-bsns-impact"},
            { "RQ_RBT_EFFECTIVE_BSNS_IMPACT","rbt-effective-bsns-impact"},
            { "RQ_RBT_FAIL_PROB","rbt-fail-prob"},
            { "RQ_RBT_CUSTOM_FAIL_PROB","rbt-custom-fail-prob"},
            { "RQ_RBT_USE_CUSTOM_FAIL_PROB","rbt-use-custom-fail-prob"},
            { "RQ_RBT_EFFECTIVE_FAIL_PROB","rbt-effective-fail-prob"},
            { "RQ_RBT_RISK","rbt-risk"},
            { "RQ_RBT_CUSTOM_RISK","rbt-custom-risk"},
            { "RQ_RBT_USE_CUSTOM_RISK","rbt-use-custom-risk"},
            { "RQ_RBT_EFFECTIVE_RISK","rbt-effective-risk"},
            { "RQ_RBT_FUNC_CMPLX","rbt-func-cmplx"},
            { "RQ_RBT_CUSTOM_FUNC_CMPLX","rbt-custom-func-cmplx"},
            { "RQ_RBT_USE_CUSTOM_FUNC_CMPLX","rbt-use-custom-func-cmplx"},
            { "RQ_RBT_EFFECTIVE_FUNC_CMPLX","rbt-effective-func-cmplx"},
            { "RQ_RBT_TESTING_LEVEL","rbt-testing-level"},
            { "RQ_RBT_CUSTOM_TESTING_LEVEL","rbt-custom-testing-level"},
            { "RQ_RBT_TESTING_HOURS","rbt-testing-hours"},
            { "RQ_RBT_CUSTOM_TESTING_HOURS","rbt-custom-testing-hours"},
            { "RQ_RBT_USE_CUSTOM_TL_AND_TE","rbt-use-custom-tl-and-te"},
            { "RQ_RBT_RND_ESTIM_EFFORT_HOURS","rbt-rnd-estim-effort-hours"},
            { "RQ_RBT_ASSESSMENT_DATA","rbt-assessment-data"},
            { "RQ_RBT_ANALYSIS_PARENT_REQ_ID","rbt-analysis-parent-req-id"},
            { "RQ_RBT_ANALYSIS_SETUP_DATA","rbt-analysis-setup-data"},
            { "RQ_RBT_ANALYSIS_RESULT_DATA","rbt-analysis-result-data"},
            { "RQ_RBT_LAST_ANALYSIS_DATE","rbt-last-analysis-date"},
            { "RQ_USER_01","user-01"},
            { "RQ_USER_02","user-02"},
            { "RQ_USER_03","user-03"},
            { "RQ_USER_04","user-04"},
            { "RQ_USER_05","user-05"},
            { "RQ_REQ_VER_STAMP","ver-stamp"},
            { "RQ_ATTACHMENT","attachment"},
            { "RQ_REQ_DATE","creation-time"},
            { "RQ_REQ_TIME","req-time"},
            { "RQ_NO_OF_SONS","no-of-sons"},
            { "RQ_VTS","last-modified"},
            { "RQ_REQUEST_ID","request-id"},
            { "RQ_REQUEST_SERVER","request-server"},
            { "RQ_REQUEST_TYPE","request-type"},
            { "RQ_REQUEST_STATUS","request-status"},
            { "RQ_REQUEST_UPDATES","request-updates"},
            { "RQ_REQUEST_ASSIGN_TO","request-assign-to"},
            { "RQ_REQUEST_NOTE","request-note"},
            { "RQ_TYPE_ID","type-id"},
            { "RQ_TARGET_RCYC_VARCHAR","target-rcyc"},
            { "RQ_TARGET_REL_VARCHAR","target-rel"},
            { "RQ_DEV_COMMENTS","comments"},
            { "RQ_HAS_RICH_CONTENT","has-rich-content"},
            { "RQ_VC_VERSION_NUMBER","vc-version-number"},
            { "RQ_VC_STATUS","vc-status"},
            { "RQ_VC_CHECKIN_USER_NAME","vc-checkin-user-name"},
            { "RQ_VC_CHECKIN_DATE","vc-checkin-date"},
            { "RQ_VC_CHECKIN_TIME","vc-checkin-time"},
            { "RQ_VC_CHECKIN_COMMENTS","vc-checkin-comments"},
            { "RQ_VC_CHECKOUT_USER_NAME","check-out-user-name"},
            { "RQ_VC_CHECKOUT_DATE","vc-checkout-date"},
            { "RQ_VC_CHECKOUT_TIME","vc-checkout-time"},
            { "RQ_VC_CHECKOUT_COMMENTS","vc-checkout-comments"},
            { "RQ_REQ_RICH_CONTENT","req-rich-content"},
            { "RQ_USER_25","user-25"}
        };*/

        public static string RequirementCustomizationName = "requirement";
        public static string DefectCustomizationName = "defect";
    }

}
