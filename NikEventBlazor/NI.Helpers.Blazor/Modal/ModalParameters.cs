using System;
using System.Collections.Generic;
using System.Text;

namespace NI.Helpers.Blazor.Modal
{
    public class ModalParameters
    {
        private Dictionary<string, object> m_parameters;

        public ModalParameters()
        {
            m_parameters = new Dictionary<string, object>();
        }

        public void Add(string parameterName, object value)
        {
            m_parameters[parameterName] = value;
        }

        public T Get<T>(string parameterName)
        {
            if (!m_parameters.ContainsKey(parameterName))
                throw new KeyNotFoundException("Not exist.");

            return (T) m_parameters[parameterName];

        }

        public T TryGet<T>(string parameterName)
        {
            if (m_parameters.ContainsKey(parameterName))
            {
                return (T) m_parameters[parameterName];
            }

            return default;
        }
    }
}
