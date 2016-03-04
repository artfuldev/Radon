namespace Radon.Core.Links
{
    /// <summary>
    ///     An enumeration that contains the link relation types.
    /// </summary>
    /// <remarks>
    ///     Reference [RFC5988]
    ///     https://www.iana.org/assignments/link-relations/link-relations.xml
    /// </remarks>
    public static class LinkRelationTypes
    {
        /// <summary>
        ///     Refers to a resource that is the subject of the link"s context.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6903], section 2
        /// </remarks>
        public const string About = "about";

        /// <summary>
        ///     Refers to a substitute for this context
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/html5/links.html#link-type-alternate]
        /// </remarks>
        public const string Alternate = "alternate";

        /// <summary>
        ///     Refers to an appendix.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/1999/REC-html401-19991224]
        /// </remarks>
        public const string Appendix = "appendix";

        /// <summary>
        ///     Refers to a collection of records, documents, or other
        ///     materials of historical interest.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/2011/WD-html5-20110113/links.html#rel-archives]
        /// </remarks>
        public const string Archives = "archives";

        /// <summary>
        ///     Refers to the context"s author.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/html5/links.html#link-type-author]
        /// </remarks>
        public const string Author = "author";

        /// <summary>
        ///     Gives a permanent link to use for bookmarking purposes.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/html5/links.html#link-type-bookmark]
        /// </remarks>
        public const string Bookmark = "bookmark";

        /// <summary>
        ///     Designates the preferred version of a resource (the IRI and its contents).
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6596]
        /// </remarks>
        public const string Canonical = "canonical";

        /// <summary>
        ///     Refers to a chapter in a collection of resources.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/1999/REC-html401-19991224]
        /// </remarks>
        public const string Chapter = "chapter";

        /// <summary>
        ///     The target IRI points to a resource which represents the collection resource for the context IRI.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6573]
        /// </remarks>
        public const string Collection = "collection";

        /// <summary>
        ///     Refers to a table of contents.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/1999/REC-html401-19991224]
        /// </remarks>
        public const string Contents = "contents";

        /// <summary>
        ///     Refers to a copyright statement that applies to the
        ///     link"s context.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/1999/REC-html401-19991224]
        /// </remarks>
        public const string Copyright = "copyright";

        /// <summary>
        ///     The target IRI points to a resource where a submission form can be obtained.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6861]
        /// </remarks>
        public const string CreateForm = "create-form";

        /// <summary>
        ///     Refers to a resource containing the most recent
        ///     item(s) in a collection of resources.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5005]
        /// </remarks>
        public const string Current = "current";

        /// <summary>
        ///     The target IRI points to a resource from which this material was derived.
        /// </summary>
        /// <remarks>
        ///     Refer [draft-hoffman-xml2rfc]
        /// </remarks>
        public const string DerivedFrom = "derivedfrom";

        /// <summary>
        ///     Refers to a resource providing information about the
        ///     link"s context.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/powder-dr/#assoc-linking]
        /// </remarks>
        public const string DescribedBy = "describedby";

        /// <summary>
        ///     The relationship A "describes" B asserts that
        ///     resource A provides a description of resource B. There are no
        ///     constraints on the format or representation of either A or B,
        ///     neither are there any further constraints on either resource.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6892]
        ///     This link relation type is the inverse of the "describedby"
        ///     relation type.  While "describedby" establishes a relation from
        ///     the described resource back to the resource that describes it,
        ///     "describes" established a relation from the describing resource to
        ///     the resource it describes.  If B is "describedby" A, then A
        ///     "describes" B.
        /// </remarks>
        public const string Describes = "describes";

        /// <summary>
        ///     Refers to a list of patent disclosures made with respect to material for which "disclosure" relation is specified.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6579]
        /// </remarks>
        public const string Disclosure = "disclosure";

        /// <summary>
        ///     Refers to a resource whose available representations
        ///     are byte-for-byte identical with the corresponding representations of
        ///     the context IRI.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6249]
        ///     This relation is for static resources.  That is, an HTTP GET
        ///     request on any duplicate will return the same representation.  It
        ///     does not make sense for dynamic or POSTable resources and should not
        ///     be used for them.
        /// </remarks>
        public const string Duplicate = "duplicate";

        /// <summary>
        ///     Refers to a resource that can be used to edit the
        ///     link"s context.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5023]
        /// </remarks>
        public const string Edit = "edit";

        /// <summary>
        ///     The target IRI points to a resource where a submission form for
        ///     editing associated resource can be obtained.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6861]
        /// </remarks>
        public const string EditForm = "edit-form";

        /// <summary>
        ///     Refers to a resource that can be used to edit media
        ///     associated with the link"s context.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5023]
        /// </remarks>
        public const string EditMedia = "edit-media";

        /// <summary>
        ///     Identifies a related resource that is potentially
        ///     large and might require special handling.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC4287]
        /// </remarks>
        public const string Enclosure = "enclosure";

        /// <summary>
        ///     An IRI that refers to the furthest preceding resource
        ///     in a series of resources.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5988]
        ///     This relation type registration did not indicate a
        ///     reference.  Originally requested by Mark Nottingham in December
        ///     2004.
        /// </remarks>
        public const string First = "first";

        /// <summary>
        ///     Refers to a glossary of terms.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/1999/REC-html401-19991224]
        /// </remarks>
        public const string Glossary = "glossary";

        /// <summary>
        ///     Refers to context-sensitive help.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/html5/links.html#link-type-help]
        /// </remarks>
        public const string Help = "help";

        /// <summary>
        ///     Refers to a resource hosted by the server indicated by
        ///     the link context.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6690]
        ///     This relation is used in CoRE where links are retrieved as a
        ///     /.well-known/core resource representation, and is the default
        ///     relation type in the CoRE Link Format.
        /// </remarks>
        public const string Hosts = "hosts";

        /// <summary>
        ///     Refers to a hub that enables registration for
        ///     notification of updates to the context.
        /// </summary>
        /// <remarks>
        ///     Refer [http://pubsubhubbub.googlecode.com]
        ///     This relation type was requested by Brett Slatkin.
        /// </remarks>
        public const string Hub = "hub";

        /// <summary>
        ///     Refers to an icon representing the link"s context.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/html5/links.html#link-type-icon]
        /// </remarks>
        public const string Icon = "icon";

        /// <summary>
        ///     Refers to an index.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/1999/REC-html401-19991224]
        /// </remarks>
        public const string Index = "index";

        /// <summary>
        ///     The target IRI points to a resource that is a member of the collection represented by the context IRI.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6573]
        /// </remarks>
        public const string Item = "item";

        /// <summary>
        ///     An IRI that refers to the furthest following resource
        ///     in a series of resources.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5988]
        ///     This relation type registration did not indicate a
        ///     reference. Originally requested by Mark Nottingham in December
        ///     2004.
        /// </remarks>
        public const string Last = "last";

        /// <summary>
        ///     Points to a resource containing the latest (e.g.,
        ///     current) version of the context.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5829]
        /// </remarks>
        public const string LatestVersion = "latest-version";

        /// <summary>
        ///     Refers to a license associated with this context.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC4946]
        ///     For implications of use in HTML, see:
        ///     http://www.w3.org/TR/html5/links.html#link-type-license
        /// </remarks>
        public const string License = "license";

        /// <summary>
        ///     Refers to further information about the link"s context,
        ///     expressed as a LRDD (Link-based Resource Descriptor Document)
        ///     resource.  See [RFC6415] for information about
        ///     processing this relation type in host-meta documents. When used
        ///     elsewhere, it refers to additional links and other metadata.
        ///     Multiple instances indicate additional LRDD resources. LRDD
        ///     resources MUST have an application/xrd+xml representation, and
        ///     MAY have others.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6415]
        /// </remarks>
        public const string Lrdd = "lrdd";

        /// <summary>
        ///     The Target IRI points to a Memento, a fixed resource that will not change state anymore.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC7089]
        ///     A Memento for an Original Resource is a resource that
        ///     encapsulates a prior state of the Original Resource.
        /// </remarks>
        public const string Memento = "memento";

        /// <summary>
        ///     Refers to a resource that can be used to monitor changes in an HTTP resource.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5989]
        /// </remarks>
        public const string Monitor = "monitor";

        /// <summary>
        ///     Refers to a resource that can be used to monitor changes in a specified group of HTTP resources.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5989]
        /// </remarks>
        public const string MonitorGroup = "monitor-group";

        /// <summary>
        ///     Indicates that the link"s context is a part of a series, and
        ///     that the next in the series is the link target.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/html5/links.html#link-type-next]
        /// </remarks>
        public const string Next = "next";

        /// <summary>
        ///     Refers to the immediately following archive resource.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5005]
        /// </remarks>
        public const string NextArchive = "next-archive";

        /// <summary>
        ///     Indicates that the contextâ€™s original author or publisher does not endorse the link target.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/html5/links.html#link-type-nofollow]
        /// </remarks>
        public const string NoFollow = "nofollow";

        /// <summary>
        ///     Indicates that no referrer information is to be leaked when following the link.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/html5/links.html#link-type-noreferrer]
        /// </remarks>
        public const string NoReferrer = "noreferrer";

        /// <summary>
        ///     The Target IRI points to an Original Resource.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC7089]
        ///     An Original Resource is a resource that exists or used to
        ///     exist, and for which access to one of its prior states may be
        ///     required.
        /// </remarks>
        public const string Original = "original";

        /// <summary>
        ///     Indicates a resource where payment is accepted.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5988]
        ///     This relation type registration did not indicate a
        ///     reference.  Requested by Joshua Kinberg and Robert Sayre.  It is
        ///     meant as a general way to facilitate acts of payment, and thus
        ///     this specification makes no assumptions on the type of payment or
        ///     transaction protocol.  Examples may include a web page where
        ///     donations are accepted or where goods and services are available
        ///     for purchase. rel=payment is not intended to initiate an
        ///     automated transaction.  In Atom documents, a link element with a
        ///     rel=payment attribute may exist at the feed/channel level and/or
        ///     the entry/item level.  For example, a rel=payment link at the
        ///     feed/channel level may point to a tip jar URI, whereas an entry/
        ///     item containing a book review may include a rel=payment link
        ///     that points to the location where the book may be purchased
        ///     through an online retailer.
        /// </remarks>
        public const string Payment = "payment";

        /// <summary>
        ///     Points to a resource containing the predecessor
        ///     version in the version history.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5829]
        /// </remarks>
        public const string PredecessorVersion = "predecessor-version";

        /// <summary>
        ///     Indicates that the link target should be preemptively cached.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/html5/links.html#link-type-prefetch]
        /// </remarks>
        public const string Prefetch = "prefetch";

        /// <summary>
        ///     Indicates that the link"s context is a part of a series, and
        ///     that the previous in the series is the link target.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/html5/links.html#link-type-prev]
        /// </remarks>
        public const string Prev = "prev";

        /// <summary>
        ///     Refers to the immediately preceding archive resource.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5005]
        /// </remarks>
        public const string PrevArchive = "prev-archive";

        /// <summary>
        ///     Refers to a resource that provides a preview of the link"s context.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6903], section 3
        /// </remarks>
        public const string Preview = "preview";

        /// <summary>
        ///     Refers to the previous resource in an ordered series
        ///     of resources.  Synonym for prev.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/1999/REC-html401-19991224]
        /// </remarks>
        public const string Previous = "previous";

        /// <summary>
        ///     Refers to a privacy policy associated with the link"s context.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6903], section 4
        /// </remarks>
        public const string PrivacyPolicy = "privacy-policy";

        /// <summary>
        ///     Identifying that a resource representation conforms
        ///     to a certain profile, without affecting the non-profile semantics
        ///     of the resource representation.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6906]
        ///     Profile URIs are primarily intended to be used as
        ///     identifiers, and thus clients SHOULD NOT indiscriminately access
        ///     profile URIs.
        /// </remarks>
        public const string Profile = "profile";

        /// <summary>
        ///     Identifies a related resource.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC4287]
        /// </remarks>
        public const string Related = "related";

        /// <summary>
        ///     Identifies a resource that is a reply to the context
        ///     of the link.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC4685]
        /// </remarks>
        public const string Replies = "replies";

        /// <summary>
        ///     Refers to a resource that can be used to search through
        ///     the link"s context and related resources.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.opensearch.org/Specifications/OpenSearch/1.1]
        /// </remarks>
        public const string Search = "search";

        /// <summary>
        ///     Refers to a section in a collection of resources.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/1999/REC-html401-19991224]
        /// </remarks>
        public const string Section = "section";

        /// <summary>
        ///     Conveys an identifier for the link's context.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC4287]
        /// </remarks>
        public const string Self = "self";

        /// <summary>
        ///     Indicates a URI that can be used to retrieve a
        ///     service document.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5023]
        ///     When used in an Atom document, this relation type specifies
        ///     Atom Publishing Protocol service documents by default.  Requested
        ///     by James Snell.
        /// </remarks>
        public const string Service = "service";

        /// <summary>
        ///     Refers to the first resource in a collection of
        ///     resources.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/1999/REC-html401-19991224]
        /// </remarks>
        public const string Start = "start";

        /// <summary>
        ///     Refers to a stylesheet.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/html5/links.html#link-type-stylesheet]
        /// </remarks>
        public const string Stylesheet = "stylesheet";

        /// <summary>
        ///     Refers to a resource serving as a subsection in a
        ///     collection of resources.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/1999/REC-html401-19991224]
        /// </remarks>
        public const string Subsection = "subsection";

        /// <summary>
        ///     Points to a resource containing the successor version
        ///     in the version history.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5829]
        /// </remarks>
        public const string SuccessorVersion = "successor-version";

        /// <summary>
        ///     Gives a tag (identified by the given address) that applies to
        ///     the current document.
        /// </summary>
        /// <remarks>
        ///     Refer [http://www.w3.org/TR/html5/links.html#link-type-tag]
        /// </remarks>
        public const string Tag = "tag";

        /// <summary>
        ///     Refers to the terms of service associated with the link"s context.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6903], section 5
        /// </remarks>
        public const string TermsOfService = "terms-of-service";

        /// <summary>
        ///     The Target IRI points to a TimeGate for an Original Resource.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC7089]
        ///     A TimeGate for an Original Resource is a resource that is
        ///     capable of datetime negotiation to support access to prior states
        ///     of the Original Resource.
        /// </remarks>
        public const string TimeGate = "timegate";

        /// <summary>
        ///     The Target IRI points to a TimeMap for an Original Resource.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC7089]
        ///     A TimeMap for an Original Resource is a resource from which
        ///     a list of URIs of Mementos of the Original Resource is available.
        /// </remarks>
        public const string TimeMap = "timemap";

        /// <summary>
        ///     Refers to a resource identifying the abstract semantic type of which the link"s context is considered to be an
        ///     instance.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC6903], section 6
        /// </remarks>
        public const string Type = "type";

        /// <summary>
        ///     Refers to a parent document in a hierarchy of
        ///     documents.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5988]
        ///     This relation type registration did not indicate a
        ///     reference.  Requested by Noah Slater.
        /// </remarks>
        public const string Up = "up";

        /// <summary>
        ///     Points to a resource containing the version history
        ///     for the context.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5829]
        /// </remarks>
        public const string VersionHistory = "version-history";

        /// <summary>
        ///     Identifies a resource that is the source of the
        ///     information in the link"s context.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC4287]
        /// </remarks>
        public const string Via = "via";

        /// <summary>
        ///     Points to a working copy for this resource.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5829]
        /// </remarks>
        public const string WorkingCopy = "working-copy";

        /// <summary>
        ///     Points to the versioned resource from which this
        ///     working copy was obtained.
        /// </summary>
        /// <remarks>
        ///     Refer [RFC5829]
        /// </remarks>
        public const string WorkingCopyOf = "working-copy-of";
    }
}