using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication4.Service;

namespace WindowsFormsApplication4.Handlers
{
    class UpdateFormHandler
    {
        private IPosInService m_Listener;
        private static UpdateFormHandler m_Instance = null;
        public static UpdateFormHandler GetInstance()
        {
            if (m_Instance == null)
                m_Instance = new UpdateFormHandler();
            return m_Instance;
        
        }
        public IPosInService Listener
        {
            get
            {
                //if (m_listener == null)
                //    throw new ArgumentNullException("m_listener", "Chưa gán Listener!!! zzz");
                return m_Listener;
            }
            set
            {
                m_Listener = value;
            }
        }
        public  void Process(byte t)
        {
            switch (t)
            {
                case 0:
                    break;
                case 1:
                    {
                        m_Listener.updateForm(t);
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
