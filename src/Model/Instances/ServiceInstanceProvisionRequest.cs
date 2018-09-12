using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenServiceBroker.Instances
{
    public class ServiceInstanceProvisionRequest : ServiceInstanceBase, IEquatable<ServiceInstanceProvisionRequest>
    {
        /// <summary>
        /// Platform specific contextual information under which the Service Instance is to be provisioned. Although most Service Brokers will not use this field, it could be helpful in determining data placement or applying custom business rules.
        /// </summary>
        /// <remarks>This will replace <see cref="OrganizationGuid"/> and <see cref="SpaceGuid"/> in future versions of the specification - in the interim both SHOULD be used to ensure interoperability with old and new implementations.</remarks>
        [JsonProperty("context")]
        public JObject Context { get; set; }

        /// <summary>
        /// Deprecated in favor of <see cref="Context"/>. The Platform GUID for the organization under which the Service Instance is to be provisioned. Although most Service Brokers will not use this field, it might be helpful for executing operations on a user's behalf. MUST be a non-empty string.
        /// </summary>
        [JsonProperty("organization_guid")]
        //[Obsolete("Deprecated in favor of " + nameof(Context))]
        public string OrganizationGuid { get; set; }

        /// <summary>
        /// Deprecated in favor of <see cref="Context"/>. The identifier for the project space within the Platform organization. Although most Service Brokers will not use this field, it might be helpful for executing operations on a user's behalf. MUST be a non-empty string.
        /// </summary>
        [JsonProperty("space_guid")]
        //[Obsolete("Deprecated in favor of " + nameof(Context))]
        public string SpaceGuid { get; set; }

        public bool Equals(ServiceInstanceProvisionRequest other)
        {
            if (other == null) return false;
            return base.Equals(other) && OrganizationGuid == other.OrganizationGuid && SpaceGuid == other.SpaceGuid;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj.GetType() == GetType() && Equals((ServiceInstanceProvisionRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ OrganizationGuid.GetHashCode();
                hashCode = (hashCode * 397) ^ SpaceGuid.GetHashCode();
                return hashCode;
            }
        }
    }
}
