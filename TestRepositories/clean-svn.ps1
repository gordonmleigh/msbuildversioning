'SvnRepo', 'SvnWC1', 'SvnWC2' |
	? { Test-Path $_ } |
	% { Remove-Item -Recurse -Force $_ }
