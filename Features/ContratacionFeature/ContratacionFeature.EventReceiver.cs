using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace LaboratorioContratacion.Features.ContratacionFeature
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("f48a7ead-3859-49a2-8be4-1586f91210b1")]
    public class ContratacionFeatureEventReceiver : SPFeatureReceiver
    {
        public static readonly SPContentTypeId ctid=new SPContentTypeId("0x010100C3316E15A95F420F8187FBBE1B9636F9");

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            var web = site.RootWeb;
            SPContentType contratacionCT= web.ContentTypes[ctid];

            if (contratacionCT == null)
            {
                contratacionCT=new SPContentType(ctid,web.ContentTypes,"Contratacion");
                web.ContentTypes.Add(contratacionCT);
            }

            contratacionCT.Description = "Un nuevo acuerdo de contratacion";
            contratacionCT.Group = "MiApp Content Types";
            SPField fldNombre = web.AvailableFields["Full Name"];
            SPFieldLink fldLinkFullName=new SPFieldLink(fldNombre);
            if (contratacionCT.FieldLinks[fldLinkFullName.Id] == null)
            {
                contratacionCT.FieldLinks.Add(fldLinkFullName);
            }

            SPField fldManager = web.AvailableFields["Manager"];
            SPFieldLink fldLinkManager=new SPFieldLink(fldManager);
            if (contratacionCT.FieldLinks[fldLinkManager.Id] == null)
            {
                contratacionCT.FieldLinks.Add(fldLinkManager);
            }

            SPField fldEquipo = web.AvailableFields["Equipo"];
            SPFieldLink fldLinkEquipo=new SPFieldLink(fldEquipo);
            if (contratacionCT.FieldLinks[fldLinkEquipo.Id] == null)
            {
                contratacionCT.FieldLinks.Add(fldLinkEquipo);
            }

            SPField fldinicio = web.AvailableFields["Inicio"];
            SPFieldLink fldLinkInicio=new SPFieldLink(fldinicio);
            if (contratacionCT.FieldLinks[fldLinkInicio.Id]==null)
            {
                contratacionCT.FieldLinks.Add(fldLinkInicio);
            }

            SPField fldFin = web.AvailableFields["Fin"];
            SPFieldLink fldLinkFin = new SPFieldLink(fldFin);
            if (contratacionCT.FieldLinks[fldLinkFin.Id] == null)
            {
                contratacionCT.FieldLinks.Add(fldLinkFin);
            }

            SPField fldAprobado = web.AvailableFields["Aprobado"];
            SPFieldLink fldLinkAprobado = new SPFieldLink(fldAprobado);
            if (contratacionCT.FieldLinks[fldLinkAprobado.Id] == null)
            {
                contratacionCT.FieldLinks.Add(fldLinkAprobado);
            }
            contratacionCT.Update(true);
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            var web = site.RootWeb;

            SPContentType contratacionCT = web.ContentTypes[ctid];
            if (contratacionCT!=null)
            {
                web.ContentTypes.Delete(ctid);
            }
        }
        // Uncomment the method below to handle the event raised after a feature has been activated.

        //public override void FeatureActivated(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
