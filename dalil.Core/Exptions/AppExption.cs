using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ApiCe.Core.Entites;
using dalil.Core.Repository;
using dalil.Core.Exptions;

namespace dalil.Core.Exptions
{
   
        public class NotFoundExption(string Message ) : Exception(Message);
      public class ConflictExtpion(string Message ) : Exception(Message);

        
    }
