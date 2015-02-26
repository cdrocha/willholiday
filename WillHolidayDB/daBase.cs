using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace WillHolidayDB
{
    public abstract class daBase
    {
        public SqlConnection conn = null;
        public SqlCommand command = null;

    }
}
