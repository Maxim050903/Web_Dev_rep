# Используем официальный образ Nginx
FROM nginx:alpine

# Устанавливаем рабочую директорию
WORKDIR /usr/share/nginx/html

# Удаляем стандартные файлы Nginx
RUN rm -rf ./*

# Копируем сборку Angular-приложения в папку Nginx
COPY ./Web_dev_front/web_front/dist/web_front .

# Копируем кастомный конфиг Nginx, если требуется
COPY ./Web_dev_front/web_front/nginx.conf .

# Указываем стандартный порт
EXPOSE 80

# Команда для запуска Nginx
CMD ["nginx", "-g", "daemon off;"]
