using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class ClaimsRepository
    {
        private readonly Queue<Claims> _ClaimsQueue = new Queue<Claims>();
        private int _count = 0;
        public bool AddClaimToQueue(Claims claims)
        {
            if (claims != null)
            {
                _count++;
                claims.ID = _count;
                _ClaimsQueue.Enqueue(claims);
                return true;
            }
            return false;
        }
        public Queue<Claims> GetAllClaims()
        {
            return _ClaimsQueue;
        }
        public Claims GetClaim()
        {
            if (_ClaimsQueue.Count > 0)
            {
                var Claim = _ClaimsQueue.Peek();
                return Claim;
            }
            else
            {
                return null;
            }
        }
        public bool NextUpClaim()
        {
            var claim = GetClaim();
            if (claim == null)
            {
                return false;
            }
            _ClaimsQueue.Dequeue();
            return true;
        }

        
        
    }
