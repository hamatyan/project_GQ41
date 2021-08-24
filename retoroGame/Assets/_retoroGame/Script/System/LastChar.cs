// 例外を使用
using System;


/// <summary>
/// 文字列の末尾文字を取得する静的クラス
/// 
/// 参考URL：https://tsu-games.hatenablog.com/entry/get-last-char　（コピペ）
/// </summary>
[Obsolete("This class is obsolete. Call TsuGames.Last instead.")]
public static class LastChar
{
	// shift の例外メッセージ
	static readonly string ShiftExceptionMessage = "\"shift\" must be opposite of a count in container to 0.";
	// count の例外メッセージ
	static readonly string CountExceptionMessage = "Sequence contains no elements.";

	/// <summary>
	/// 文字列の末尾文字
	/// </summary>
	/// <param name="str">文字列</param>
	/// <param name="shift">末尾インデックスからのシフト（０以下）</param>
	/// <returns>指定したインデックスの文字</returns>
	[Obsolete("This method is obsolete. Call TsuGames.Last.LastChar instead.")]
	public static char GetLastChar(this string str, int shift = 0)
	{
		// 例外が生じるおそれのある命令
		try
		{
			// 指定したインデックスの文字を返す
			return str.ToCharArray(LastIndexNumberOf(str) + shift, 1)[0];
		}
		// 引数の例外をキャッチした場合
		catch (ArgumentOutOfRangeException)
		{
			// 例外を投げる
			throw new ArgumentOutOfRangeException(nameof(shift), ShiftExceptionMessage);
		}
	}

	/// <summary>
	/// 文字列の末尾インデックス番号
	/// </summary>
	/// <param name="str">文字列</param>
	/// <returns>末尾インデックス番号</returns>
	static int LastIndexNumberOf(string str)
	{
		// 文字列の文字数を取得
		var count = str.Length;

		// 文字が１つもない場合
		if (count < 1)
		{
			// メソッド呼び出しの例外を投げる
			throw new InvalidOperationException(CountExceptionMessage);
		}

		// 末尾インデックス番号をリターン
		return count - 1;
	}
}
