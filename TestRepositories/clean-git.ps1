'Git1', 'Git2', 'Git3' |
	? { Test-Path $_ } |
	% { Remove-Item -Recurse -Force $_ }
