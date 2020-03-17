using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svnTrack.Models.Svn
{
    /// <summary>
    /// This is the class that holds the information for a repository
    /// </summary>
    public class SvnRepository : BaseModel
    {
        string _name;
        int _nrOfChanges;

        public SvnRepository(string name, int nrOfChanges)
        {
            Name = name;
            NrOfChanges = nrOfChanges;
        }

        public string Name 
        { 
            get => _name;
            set
            {
                if(_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            } 
        }

        public int NrOfChanges 
        { 
            get => _nrOfChanges; 
            set
            {
                if (_nrOfChanges != value)
                {
                    _nrOfChanges = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
