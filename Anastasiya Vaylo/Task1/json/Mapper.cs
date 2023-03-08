using JsonLinq.DTO;
using JsonLinq.Model;

namespace JsonLinq
{
    public class Mapper
    {
        private AviaRestrictionMessage _message;

        public Mapper(AviaRestrictionMessage message)
        {
            _message = message;
        }

        public RestrictionMessage Map()
        {
            return new RestrictionMessage
            {
                EffectiveFrom = _message.DataItem.EffectiveFrom,
                EffectiveTo = _message.DataItem.EffectiveTo,
                PublishedInfo = _message.DataItem.PublishedBy + ", reviewed by " + _message.DataItem.ReviewedBy,
                Reason = _message.Info.Reason
            };
        }
    }
}