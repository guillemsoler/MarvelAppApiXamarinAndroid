package crc642cc2c46accdc45b4;


public class MyCustomListAdapter_ViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("AppXamAndroid.MyCustomListAdapter+ViewHolder, AppXamAndroid", MyCustomListAdapter_ViewHolder.class, __md_methods);
	}


	public MyCustomListAdapter_ViewHolder ()
	{
		super ();
		if (getClass () == MyCustomListAdapter_ViewHolder.class)
			mono.android.TypeManager.Activate ("AppXamAndroid.MyCustomListAdapter+ViewHolder, AppXamAndroid", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
