using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace MyTask
{
    /*
     * implementazione del task
     * Il nome della classe è importante visto che deve essere lo stesso che poi inserirò nel manifest
    */
    public sealed class FirstTask : IBackgroundTask
    {
        //unico metodo da implementare che verrà eseguito all'avvio del task
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            /*
             * un semplice esempio con un Toast
             * per abilitare i toast aprire il manifest->applicazione e sotto la voce notifiche mettere "SI" in Popup supportati
            */

            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList textElements = toastXml.GetElementsByTagName("text");
            textElements[0].AppendChild(toastXml.CreateTextNode("Il mio primo task"));
            textElements[1].AppendChild(toastXml.CreateTextNode("Messaggio arrivato dal background task!"));
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toastXml));

        }
    }
}
